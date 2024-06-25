using Microsoft.Extensions.Logging;

namespace Application.Abstractions.Behaviors;

internal sealed class RequestLoggingPipelineBehavior<TRequest, TResponse>(
    ILogger<RequestLoggingPipelineBehavior<TRequest, TResponse>> logger
) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
    where TResponse : Result
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;

        try
        {
            logger.LogInformation("Processing request {RequestName}", requestName);

            var result = await next();

            logger.LogInformation("Completed request {RequestName}", requestName);

            return result;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Exception request {RequestName} with error", requestName);
            throw;
        }
    }
}
