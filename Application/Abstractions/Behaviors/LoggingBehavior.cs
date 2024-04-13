using Microsoft.Extensions.Logging;

namespace Application.Abstractions.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommandBaseCustom
{
    private readonly ILogger<TRequest> _logger;

    public LoggingBehavior(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;

        try
        {
            _logger.LogInformation("Processing request {RequestName}", requestName);

            var result = await next();

            _logger.LogInformation("Completed request {RequestName}", requestName);

            return result;
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "request {RequestName} with error", requestName);

            throw;
        }
    }
}
