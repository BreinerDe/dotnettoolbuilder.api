using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.ToolBuilder.Api.Services.JsonFileCreator
{
    public static class AddJsonFileCreatorServiceExtension
    {
        public static void AddJsonFileCreatorService(this IServiceCollection services)
        {
            services.AddSingleton<IJsonFileCreatorService, JsonFileCreatorService>();
        }
    }
}