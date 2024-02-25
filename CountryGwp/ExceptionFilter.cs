using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace CountryGwp;

/// <summary>
/// Common exception handling logic for controllers.
/// </summary>
public sealed class ExceptionFilter(ILogger<ExceptionFilter> logger) : IExceptionFilter
{
    /// <inheritdoc/>
    public void OnException(ExceptionContext context)
    {
        var ex = context.Exception;
        logger.LogError(ex, $"{context.ActionDescriptor.DisplayName} threw an exception.");
        var response = context.HttpContext.Response;

        response.StatusCode = (int)(ex switch
        {
            ArgumentException => HttpStatusCode.BadRequest,
           // Add more expected types here
            _ => HttpStatusCode.InternalServerError
        });
    }
}
