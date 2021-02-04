using AspNetCore.Simple.Sdk.Startups;
using Dotnet.ToolBuilder.Api.API.DotnetTool;
using Dotnet.ToolBuilder.Api.Extensions;
using DotNetTool.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FileService = FileSystem.Abstraction.FileService;
using IFileService = FileSystem.Abstraction.IFileService;

namespace Dotnet.ToolBuilder.Api
{
    public class Startup : SimpleStartup
    {

        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment) : base(configuration, webHostEnvironment, typeof(Startup).Assembly, new PathString("/api/toolbuilder"), "Pulse Core API")
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddDotnetTool();

            services.AddSingleton<IFileService, FileService>();

            var dotnetTool = DotNetToolFactory.Create();

            services.AddDotnetTool();
            services.AddSingleton<IDotNetTool>(dotnetTool);
            services.AddSingletonOption<DotnetToolBuilderSettings>(Configuration);
            services.AddSingletonOption<FileSettings>(Configuration);
        }

    }
}
