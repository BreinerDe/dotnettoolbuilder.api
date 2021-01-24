using System.IO;
using System.Threading.Tasks;
using Dotnet.ToolBuilder.Api.ErrorHandling;
using Dotnet.ToolBuilder.Api.Services.JsonFileCreator;
using Dotnet.ToolBuilder.Api.Services.Stream;
using Dotnet.ToolBuilder.Api.Settings;
using DotNetTool.Service;

namespace Dotnet.ToolBuilder.Api.Services.DotnetToolBuilder
{
    public class DotnetToolBuilderService
    {
        private readonly IDotNetTool dotNetTool;
        private readonly IJsonFileCreatorService jsonFileCreatorService;
        private readonly DotnetToolBuilderSettings dotnetToolBuilderSettings;
        private readonly StreamService streamService;
        private readonly ResultCodeHandler resultCodeHandler;

        public DotnetToolBuilderService(IDotNetTool dotNetTool,
                                        IJsonFileCreatorService jsonFileCreatorService,
                                        DotnetToolBuilderSettings dotnetToolBuilderSettings,
                                        StreamService streamService,
                                        ResultCodeHandler resultCodeHandler)
        {
            this.dotNetTool = dotNetTool;
            this.jsonFileCreatorService = jsonFileCreatorService;
            this.dotnetToolBuilderSettings = dotnetToolBuilderSettings;
            this.streamService = streamService;
            this.resultCodeHandler = resultCodeHandler;
        }

        public async Task<MemoryStream> GetDotnetToolAsync(Models.DotNetTool data)
        {
            using var jsonFile = jsonFileCreatorService.CreateJsonFrom(data);
            var zipName = Path.Combine(jsonFile.FileInfo.Directory.FullName, $"{data.ProjectName}s.zip");
            var result = await dotNetTool.RunAsync(dotnetToolBuilderSettings.BaseCommand, $"-ff {jsonFile.FileInfo.FullName} -az {zipName}");
            resultCodeHandler.HandleDotNetToolBuilderResult(result);
            var file = streamService.ReadFileToMemoryStream(zipName);

            //To be deleted when Toolbuilder is updated
            Directory.Delete(Path.Combine(Directory.GetCurrentDirectory(), data.ProjectName), true);

            return file;
        }
    }
}