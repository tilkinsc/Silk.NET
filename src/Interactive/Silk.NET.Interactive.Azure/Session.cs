// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;

namespace Silk.NET.Interactive.Azure;

public class Session : ISession
{
    private readonly IDurableEntityContext _context;

    private readonly ILogger<Session> _logger;

    public Session(IDurableEntityContext context, ILogger<Session> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task RunAsync(CmdOrchestrateSession command)
    {
        var rand = new Random(DateTime.UtcNow.Millisecond);
        var delay = TimeSpan.FromSeconds(rand.Next(60));

        _logger.LogInformation($"starting executing {command.Id} for {delay} ...");

        await Task.Delay(delay);

        var orchestratorId = new EntityId(nameof(SessionOrchestrator), command.Id.ToString());
        _context.SignalEntity<ISessionOrchestrator>(orchestratorId, r => r.OnCompleted());
    }

    [FunctionName(nameof(Session))]
    public static Task Run([EntityTrigger] IDurableEntityContext ctx) => ctx.DispatchAsync<Session>(ctx);
}