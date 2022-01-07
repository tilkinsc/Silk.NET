// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using DurableTask.Core.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Silk.NET.Interactive.Azure;

public class SessionFunctions
{
    private const string QueueName = "try-silkdotnet-jobs";
    private const string QueueConnectionName = "AzureWebJobsStorage";

    [FunctionName(nameof(NewSession))]
    public static async Task<IActionResult> NewSession
    (
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = Routes.PostCreateSession)]
        HttpRequest req,
        [Queue(QueueName, Connection = QueueConnectionName)]
        CloudQueue queue
    )
    {
        var inCmd = await JsonSerializer.DeserializeAsync<CmdNewSession>(req.Body);
        var outCmd = new CmdOrchestrateSession(Guid.NewGuid(), inCmd);
        await queue.AddMessageAsync(new CloudQueueMessage(JsonSerializer.Serialize(outCmd)));
        return new CmdNewSessionAck(true, outCmd.Id).ToResult();
    }

    [FunctionName(nameof(GetInfo))]
    public static async Task<IActionResult> GetInfo
    (
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = Routes.GetSessionInfo)]
        HttpRequest req,
        [DurableClient] IDurableEntityClient client,
        string processId
    )
    {
        var entityId = new EntityId(nameof(SessionOrchestrator), processId);
        var status = await client.ReadEntityStateAsync<SessionOrchestrator>(entityId);

        if (!status.EntityExists || status.EntityState is null)
        {
            return new NotFoundResult();
        }

        var entity = status.EntityState;

        if (!entity.IsActive)
        {
            return new OkObjectResult(entity);
        }

        return new JsonResult(new CmdGetEventsAck()) { StatusCode = 202 };
    }

    [FunctionName(nameof(RunProcess))]
    public static async Task RunProcess
    (
        [QueueTrigger(QueueName, Connection = QueueConnectionName)]
        string message,
        [DurableClient] IDurableEntityClient client
    )
    {
        var command = JsonSerializer.Deserialize<CmdOrchestrateSession>(message);
        var entityId = new EntityId(nameof(SessionOrchestrator), command.Id.ToString());
        await client.SignalEntityAsync<ISessionOrchestrator>(entityId, e => e.Start(command));
    }

    // Prevent Azure storage costs going through the roof!
    [FunctionName(nameof(GarbageCollector))]
    public static async Task GarbageCollector
    (
        [TimerTrigger("0 */1 * * *")] TimerInfo timer,
        [DurableClient] IDurableEntityClient client
    )
    {
        var query = new EntityQuery
        {
            PageSize = 100,
            FetchState = true
        };

        using CancellationTokenSource source = new CancellationTokenSource();
        var token = source.Token;
        do
        {
            var result = await client.ListEntitiesAsync(query, token);
            var entities = result.Entities;

            query.ContinuationToken = result.ContinuationToken;
            foreach (var entity in entities)
            {
                var state = entity.State.ToObject<SessionOrchestrator>();
                // an orchestrator is garbage if:
                // - it's not active and hasn't done anything (i.e. had its events popped) for the past 5 minutes]
                // - it's active and has exceeded the allowed execution time
                if (!state.IsActive &&
                    entity.LastOperationTime < DateTime.UtcNow.Subtract(TimeSpan.FromMinutes(5)) ||
                    state.IsActive &&
                    state.StartTime < DateTime.UtcNow.Subtract(TimeSpan.FromSeconds(Limits.MaximumExecutionSeconds)))
                {
                }
            }
        } while (query.ContinuationToken != null);
    }
}
