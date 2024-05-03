using Application.Abstractions.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Minimal.Middlewares;

public class ExceptionHandling(RequestDelegate next, ILogger<ExceptionHandling> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Exception occurred: {Message}", ex.Message);

            var exceptionDetails = GetExceptionDetails(ex);

            var problemDetails = new ProblemDetails
            {
                Status = exceptionDetails.Status,
                Type = exceptionDetails.Type,
                Title = exceptionDetails.Title,
                Detail = exceptionDetails.Detail,
                Instance = context.Request.Path
            };

            if (exceptionDetails.Errors is not null)
            {
                problemDetails.Extensions["errors"] = exceptionDetails.Errors;
            }

            context.Response.StatusCode = exceptionDetails.Status;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
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