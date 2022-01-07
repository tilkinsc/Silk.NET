using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Silk.NET.Private.Interactive.SourceGenerator;

[Generator]
public class JsonEventCruftSourceGenerator : ISourceGenerator, ISyntaxContextReceiver
{
    private Dictionary<int, string>? _types;
    public void Execute(GeneratorExecutionContext context)
    {
        var source = new StringBuilder();
        source.AppendLine
        (
            $@"
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Nodes;

namespace Silk.NET.Interactive.Common.Events;

internal class JsonEventConverter : JsonConverter<JsonEvent>
{{
    public override bool CanConvert(Type type) =>
}}"
        );
        foreach (var kvp in _types ?? Enumerable.Empty<KeyValuePair<int, string>>())
        {
            source.AppendLine($"type == typeof({kvp.Value}) || ");
        }

        source.Append("false;"); // lol
        source.AppendLine
        (
            $@"
public override JsonEvent Read(
    ref Utf8JsonReader reader,
    Type typeToConvert,
    JsonSerializerOptions options)
{{
    if (reader.TokenType != JsonTokenType.StartObject)
    {{
        throw new JsonException();
    }}

    if (!reader.Read()
            || reader.TokenType != JsonTokenType.PropertyName
            || reader.GetString() != ""kind"")
    {{
        throw new JsonException();
    }}

    if (!reader.Read() || reader.TokenType != JsonTokenType.Number)
    {{
        throw new JsonException();
    }}

    var evId = reader.GetInt32();
    JsonEvent ret;
    switch (evId)
    {{
"
        );
        
        
        foreach (var kvp in _types ?? Enumerable.Empty<KeyValuePair<int, string>>())
        {
            source.AppendLine(@$"
case {kvp.Key}:
    if (!reader.Read() || reader.GetString() != ""value"")
    {{
        throw new JsonException();
    }}
    if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
    {{
        throw new JsonException();
    }}
    ret = ({kvp.Value})JsonSerializer.Deserialize<{kvp.Value}>(ref reader, options);
    break;
");
        }

        source.AppendLine
        (
            $@"
default:
     throw new NotSupportedException($""Event not supported: {{evId}}"");
}}

    if (!reader.Read() || reader.TokenType != JsonTokenType.EndObject)
    {{
        throw new JsonException();
    }}

    return ret;
}}


public override void Write(
    Utf8JsonWriter writer,
    JsonEvent value,
    JsonSerializerOptions options)
{{
    writer.WriteStartObject();
    switch (value.Value) 
{{"
        );
        foreach (var kvp in _types ?? Enumerable.Empty<KeyValuePair<int, string>>())
        {
            var var = $"the{kvp.Value}";
            source.AppendLine(@$"
case {kvp.Value} {var}:
    writer.WriteNumber(""kind"", {kvp.Key});
    writer.WritePropertyName(""value"");
    JsonSerializer.Serialize(writer, {var});
    break;
");
        }

        source.AppendLine
        (
            @"
default:
     throw new NotSupportedException($""Event not supported: {value.Value.GetType().Name}"");
}
    writer.WriteEndObject();
}
"
        );
        context.AddSource($"{typeName}.g.cs", source);
    }

    public void Initialize(GeneratorInitializationContext context)
    {
        _types = new();
        context.RegisterForSyntaxNotifications(() => this);
    }

    public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
    {
        if (context.Node is not RecordDeclarationSyntax cds)
        {
            return;
        }

        var eventAttr = cds.AttributeLists.Select(x => x.Attributes.FirstOrDefault(y => y.Name.ToString() == "Event"))
            .FirstOrDefault(x => x is not null);
        if (eventAttr is null)
        {
            return;
        }

        var eventIdStr = eventAttr.ArgumentList?.Arguments.FirstOrDefault()?.Expression.ToString();
        if (eventIdStr is null)
        {
            return;
        }

        var eventId = int.Parse(eventIdStr);
        var symbol = context.SemanticModel.GetDeclaredSymbol(cds);
        if (symbol is INamedTypeSymbol sym)
        {
            if (sym.ContainingNamespace.ToString() == "Silk.NET.Interactive.Common.Events")
            {
                _types?.Add(eventId, sym.Name);
            }
        }
    }
}