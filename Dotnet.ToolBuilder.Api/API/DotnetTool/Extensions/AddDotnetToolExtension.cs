using System;
using FileSystem.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.ToolBuilder.Api.API.DotnetTool
{
    public static class AddDotnetToolExtension
    {
        public static void AddDotnetTool(this IServiceCollection services)
        {
            var directoryService = new DirectoryService();
            directoryService.SetCurrentDirectoryInfo(new DirectoryInfo(new System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory)));
            services.AddSingleton<IDirectoryService>(directoryService);

            services.AddSingleton<CleanupService>();
            services.AddSingleton<DirectoryBuilder>();
            services.AddSingleton<DotnetToolBuilderService>();
            services.AddSingleton<DotNetToolExecutor>();
            services.AddSingleton<JsonFileCreatorService>();
        }
    }
}