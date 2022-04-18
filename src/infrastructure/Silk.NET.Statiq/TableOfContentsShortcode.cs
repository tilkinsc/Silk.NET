// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Silk.NET.Statiq.TableOfContents;
using Statiq.Common;

namespace Silk.NET.Statiq;

public class TableOfContentsShortcode : IShortcode
{
    public Task<IEnumerable<ShortcodeResult>> ExecuteAsync
    (
        KeyValuePair<string, string>[] args,
        string content,
        IDocument document,
        IExecutionContext context
    ) => Task.FromResult
    (
        Enumerable.Repeat
        (
            new ShortcodeResult
            (
                document.TryGetValue(nameof(TableOfContentsModel), out var toc) &&
                toc is TableOfContentsModel { Node: { } } model
                    ? AsOrderedList(document, model)
                    : string.Empty
            ), 1
        )
    );

    private static string AsOrderedList(IDocument doc, TableOfContentsModel model)
    {
        var sb = new StringBuilder();
        AsOrderedList(doc, model.Node!, sb);
        return sb.ToString();
    }

    private static void AsOrderedList(IDocument doc, TableOfContentsElement element, StringBuilder builder)
    {
        var isRoot = builder.Length == 0;
        if (isRoot)
        {
            builder.Append("<ul>");
        }

        builder.Append("<li>");
        builder.Append($"<a href=\"{SilkPage.GetInputUrl(element.Href.TrimStart('~'), doc)}\">{element.Name}</a>");
        if (element.Children?.Count > 0)
        {
            builder.Append("<ul>");
            foreach (var child in element.Children)
            {
                AsOrderedList(doc, child, builder);
            }

            builder.Append("</ul>");
        }
        
        if (isRoot)
        {
            builder.Append("</ul>");
        }
    }
}
