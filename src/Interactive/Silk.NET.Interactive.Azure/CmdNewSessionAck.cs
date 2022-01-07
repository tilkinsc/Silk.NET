using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Silk.NET.Interactive.Azure;

public readonly record struct CmdNewSessionAck
(
    bool Success,
    Guid? Id
)
{
    public IActionResult ToResult() => new Result(this);
    private class Result : JsonResult
    {
        private readonly CmdNewSessionAck _cmd;
        public Result(CmdNewSessionAck value) : base(value) => _cmd = value;
        public override Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.StatusCode = 202;
            var req = context.HttpContext.Request;
            var uri = new UriBuilder(req.Scheme, req.Host.Host)
            {
                Path = $@"api/{Routes.GetSessionInfo.Replace("{sessionId}", _cmd.Id.ToString())}"
            };

            if (req.Host.Port.HasValue)
            {
                uri.Port = req.Host.Port.Value;
            }

            context.HttpContext.Response.Headers.Add(@"Location", uri.ToString());
            return base.ExecuteResultAsync(context);
        }
    }
}