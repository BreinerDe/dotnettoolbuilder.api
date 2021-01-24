using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.ToolBuilder.Api.Services.Stream
{
    public static class AddStreamServiceExtension
    {
        public static void AddStreamService(this IServiceCollection services)
        {
            services.AddSingleton<StreamService>();
        }
    }
}