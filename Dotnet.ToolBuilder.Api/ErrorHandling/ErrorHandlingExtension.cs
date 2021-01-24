using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.ToolBuilder.Api.ErrorHandling
{
    public static class ErrorHandlingExtension
    {
        public static void AddErrorHandling(this IServiceCollection services)
        {
            services.AddSingleton<ErrorHandlingMiddleware>();
            services.AddSingleton<ResultCodeHandler>();
        }
    }
}