using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.ToolBuilder.Api.Services.DotnetToolBuilder
{
    public static class AddDotnetToolBuilderServiceExtension
    {
        public static void AddDotnetToolBuilderService(this IServiceCollection services)
        {
            services.AddSingleton<DotnetToolBuilderService>();
        }
    }
}