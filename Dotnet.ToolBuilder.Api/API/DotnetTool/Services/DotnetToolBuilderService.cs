using System.IO;
using System.Threading.Tasks;

namespace Dotnet.ToolBuilder.Api.API.DotnetTool
{
    public class DotnetToolBuilderService
    {
        private readonly JsonFileCreatorService jsonFileCreatorService;
        private readonly DotNetToolExecutor dotNetToolExecutor;
        private readonly CleanupService cleanupService;

        public DotnetToolBuilderService(JsonFileCreatorService jsonFileCreatorService, DotNetToolExecutor dotNetToolExecutor, CleanupService cleanupService)
        {
            this.jsonFileCreatorService = jsonFileCreatorService;
            this.dotNetToolExecutor = dotNetToolExecutor;
            this.cleanupService = cleanupService;
        }

        public async Task<byte[]> GetDotnetToolAsync(DotNetTool data, string consoleParameter = "")
        {
            using var jsonFile = jsonFileCreatorService.CreateJsonFrom(data);
            var zipName = Path.Combine(jsonFile.FileInfo.Directory.FullName, $"{data.ProjectName}s.zip");

            await dotNetToolExecutor.ExecuteAsync(consoleParameter, jsonFile, zipName).ConfigureAwait(false);

            var file = await File.ReadAllBytesAsync(zipName).ConfigureAwait(false);
            cleanupService.CleanUp(data);

            return file;
        }


    }
}