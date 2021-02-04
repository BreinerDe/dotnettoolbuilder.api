using System;
using FileSystem.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.ToolBuilder.Api.Extensions
{
    public static class AddDirectorServiceExtension
    {
        public static void AddDirectoryService(this IServiceCollection services)
        {
            var directoryService = new DirectoryService();
            directoryService.SetCurrentDirectoryInfo(new DirectoryInfo(new System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory)));
            services.AddSingleton<IDirectoryService>(directoryService);
        }
    }
}