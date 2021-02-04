using System.IO;
using AspNetCore.Simple.Sdk.Serializer.Json;
using FileSystem.Abstraction;

namespace Dotnet.ToolBuilder.Api.API.DotnetTool
{
    public class JsonFileCreatorService
    {
        private readonly IJsonSerializer jsonSerializer;
        private readonly FileSettings fileSettings;
        private readonly IFileService fileService;
        private readonly DirectoryBuilder directoryBuilder;

        public JsonFileCreatorService(IJsonSerializer jsonSerializer, FileSettings fileSettings, IFileService fileService, DirectoryBuilder directoryBuilder)
        {
            this.jsonSerializer = jsonSerializer;
            this.fileSettings = fileSettings;
            this.fileService = fileService;
            this.directoryBuilder = directoryBuilder;
        }

        public DisposableFile CreateJsonFrom(DotNetTool model)
        {
            var directory = directoryBuilder.CreateFolderInCurrentDirectory();
            var jsonData = jsonSerializer.Serialize(model);
            var fileInfo = fileService.GetFileInfo(Path.Combine(directory.FullName, fileSettings.JsonDataFileName));
            fileInfo.WriteAllText(jsonData);
            return new DisposableFile(fileInfo);
        }
    }
}