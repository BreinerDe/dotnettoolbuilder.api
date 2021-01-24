using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.ToolBuilder.Api.Services.DirectoryBuilder
{
    public static class AddDirectoryBuilderExtension
    {
        public static void AddDirectoryBuilder(this IServiceCollection services)
        {
            services.AddSingleton<IDirectoryBuilder, DirectoryBuilder>();
        }
    }
}