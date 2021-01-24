using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Dotnet.ToolBuilder.Api.ErrorHandling
{
    internal class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (ProblemDetailsException exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, ProblemDetailsException exception)
        {
            context.Response.Clear();
            context.Response.ContentType = MediaTypeNames.Application.Json;

            if (exception.ProblemDetails.Status != null)
            {
                context.Response.StatusCode = exception.ProblemDetails.Status.Value;
            }

            return context.Response.WriteAsJsonAsync(exception.ProblemDetails);
        }
    }
}