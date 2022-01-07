// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Silk.NET.Interactive.Azure;

[JsonObject(MemberSerialization.OptIn)]
public class SessionOrchestrator : ISessionOrchestrator
{
    private readonly IDurableEntityContext _context;
    private readonly ILogger<SessionOrchestrator> _logger;

    [JsonPropertyName("id")]
    [JsonProperty("id")]
    public Guid Id { get; private set; }

    [JsonPropertyName("active")]
    [JsonProperty("active")]
    public bool IsActive { get; private set; }
    
    [JsonPropertyName("started")]
    [JsonProperty("started")]
    public DateTime StartTime { get; private set; }

    public SessionOrchestrator(IDurableEntityContext context, ILogger<SessionOrchestrator> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void Start(CmdOrchestrateSession cmd)
    {
        Id = cmd.Id;
        IsActive = true;
        StartTime = DateTime.UtcNow;
        _logger.LogInformation($"starting new process {Id} ...");
        var runnerId = new EntityId(nameof(Session), cmd.Id.ToString());
        _context.SignalEntity<ISession>(runnerId, r => r.RunAsync(cmd));
    }

    public void OnCompleted()
    {
        IsActive = false;
        _logger.LogInformation($"process {Id} completed!");
    }

    [FunctionName(nameof(SessionOrchestrator))]
    public static Task Run([EntityTrigger] IDurableEntityContext ctx) => ctx.DispatchAsync<SessionOrchestrator>(ctx);
}
