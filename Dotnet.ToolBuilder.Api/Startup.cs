using Dotnet.ToolBuilder.Api.ErrorHandling;
using Dotnet.ToolBuilder.Api.Extensions;
using Dotnet.ToolBuilder.Api.Services.DirectoryBuilder;
using Dotnet.ToolBuilder.Api.Services.DotnetToolBuilder;
using Dotnet.ToolBuilder.Api.Services.JsonFileCreator;
using Dotnet.ToolBuilder.Api.Services.JsonSerializer;
using Dotnet.ToolBuilder.Api.Services.Stream;
using Dotnet.ToolBuilder.Api.Settings;
using DotNetTool.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using FileService = FileSystem.Abstraction.FileService;
using IFileService = FileSystem.Abstraction.IFileService;

namespace Dotnet.ToolBuilder.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; init; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddJsonFileCreatorService();
            services.AddErrorHandling();
            services.AddJsonSerializer();
            services.AddDotnetToolBuilderService();
            services.AddDirectoryBuilder();
            services.AddStreamService();

            services.AddSingleton<IFileService, FileService>();

            var dotnetTool = DotNetToolFactory.Create();

            services.AddDirectoryService();
            services.AddSingleton<IDotNetTool>(dotnetTool);
            services.AddSingletonOption<DotnetToolBuilderSettings>(Configuration);
            services.AddSingletonOption<FileSettings>(Configuration);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dotnet.ToolBuilder.Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseCors("AllowAll");

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dotnet.ToolBuilder.Api v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
