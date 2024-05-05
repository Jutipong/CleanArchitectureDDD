using Application.Abstractions.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Api.Minimal.Extensions;

internal sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

        var exceptionDetails = GetExceptionDetails(exception);

        var problemDetails = new ProblemDetails
        {
            Status = exceptionDetails.Status,
            Type = exceptionDetails.Type,
            Title = exceptionDetails.Title,
            Detail = exceptionDetails.Detail,
            Instance = httpContext.Request.Path
        };

        if (exceptionDetails.Errors is not null)
        {
            problemDetails.Extensions["errors"] = exceptionDetails.Errors;
        }

        httpContext.Response.StatusCode = exceptionDetails.Status;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }

    private static ExceptionDetails GetExceptionDetails(Exception ex)
    {
        return ex switch
        {
            ValidationException validationException
                => new ExceptionDetails(
                    StatusCodes.Status400BadRequest,
                    "ValidationFailure",
                    "Validation error",
                    "One or more validation failures have occurred.",
                    validationException.Errors
                ),
            _
                => new ExceptionDetails(
                    StatusCodes.Status500InternalServerError,
                    "ServerError",
                    "Server error",
                    "An unexpected error occurred.",
                    null
                )
        };
    }

    private record ExceptionDetails(int Status, string Type, string Title, string Detail, IEnumerable<object>? Errors);
}
