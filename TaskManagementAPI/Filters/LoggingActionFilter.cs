using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TaskManagementAPI.Filters
{
    public class LoggingActionFilter : IActionFilter
    {
        private readonly ILogger<LoggingActionFilter> _logger;
        private Stopwatch? _stopwatch;

        public LoggingActionFilter(ILogger<LoggingActionFilter> logger)
        {
            _logger = logger;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch = Stopwatch.StartNew();

            var controllerName = context.ActionDescriptor.RouteValues["controller"];
            var actionName = context.ActionDescriptor.RouteValues["action"];
            var parameters = context.ActionArguments;

            _logger.LogInformation("Executing {Controller}.{Action} with arguments {@Arguments}",
                controllerName, actionName, parameters);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch!.Stop();

            var controllerName = context.ActionDescriptor.RouteValues["controller"];
            var actionName = context.ActionDescriptor.RouteValues["action"];
            var result = context.Result;

            if (context.Exception == null)
            {
                _logger.LogInformation("Executed {Controller}.{Action} successfully in {ElapsedMilliseconds}ms. Result: {@Result}",
                    controllerName, actionName, _stopwatch.ElapsedMilliseconds, result);
            }
            else
            {
                _logger.LogError(context.Exception, "Error executing {Controller}.{Action} after {ElapsedMilliseconds}ms",
                    controllerName, actionName, _stopwatch.ElapsedMilliseconds);
            }
        }

    }
}
