using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using System;

public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
{
    private readonly ILogger<CustomExceptionFilterAttribute> _logger;

    public CustomExceptionFilterAttribute(ILogger<CustomExceptionFilterAttribute> logger)
    {
        _logger = logger;
    }

    public override void OnException(ExceptionContext context)
    {
        LogException(context.Exception);

        context.Result = new ViewResult
        {
            ViewName = "_Error",
            ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), context.ModelState)
            {
                { "ErrorMessage", "An error occurred while processing your request." }
            }
        };

        context.ExceptionHandled = true;
    }

    private void LogException(Exception exception)
    {
        _logger.LogError(exception, "An error occurred in the application.");
    }
}
