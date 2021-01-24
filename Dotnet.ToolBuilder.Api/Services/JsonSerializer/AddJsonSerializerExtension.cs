using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.ToolBuilder.Api.Services.JsonSerializer
{
    public static class AddJsonSerializerExtension
    {
        public static void AddJsonSerializer(this IServiceCollection services)
        {
            services.AddSingleton<IJsonSerializer, JsonSerializer>();
        }
    }
}