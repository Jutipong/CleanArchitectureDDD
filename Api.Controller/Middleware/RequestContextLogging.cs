using Serilog.Context;

namespace Api.Controller.Middleware;

internal sealed class RequestContextLogging(RequestDelegate next)
{
    private const string CORRELATIONIDHEADERNAME = "X-Correlation-Id";

    public Task Invoke(HttpContext context)
    {
        using (LogContext.PushProperty("CorrelationId", GetCorrelationId(context)))
        {
            return next.Invoke(context);
        }
    }

    private static string GetCorrelationId(HttpContext context)
    {
        context.Request.Headers.TryGetValue(CORRELATIONIDHEADERNAME, out var correlationId);

        return correlationId.FirstOrDefault() ?? Guid.NewGuid().ToString();
    }
}
