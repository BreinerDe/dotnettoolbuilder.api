using System;
using System.IO;
using Dotnet.ToolBuilder.Api.Models;
using Dotnet.ToolBuilder.Api.Services.DirectoryBuilder;
using Dotnet.ToolBuilder.Api.Services.JsonSerializer;
using Dotnet.ToolBuilder.Api.Settings;
using FileSystem.Abstraction;

namespace Dotnet.ToolBuilder.Api.Services.JsonFileCreator
{
    public class JsonFileCreatorService : IJsonFileCreatorService
    {
        private readonly IJsonSerializer jsonSerializer;
        private readonly FileSettings fileSettings;
        private readonly IFileService fileService;
        private readonly IDirectoryBuilder directoryBuilder;

        public JsonFileCreatorService(IJsonSerializer jsonSerializer, FileSettings fileSettings, IFileService fileService, IDirectoryBuilder directoryBuilder)
        {
            this.jsonSerializer = jsonSerializer;
            this.fileSettings = fileSettings;
            this.fileService = fileService;
            this.directoryBuilder = directoryBuilder;
        }

        public DisposableFile CreateJsonFrom(Models.DotNetTool model)
        {
            var directory = directoryBuilder.CreateFolderInCurrentDirectory();
            var jsonData = jsonSerializer.Serialize(model);
            var fileInfo = fileService.GetFileInfo(Path.Combine(directory.FullName, fileSettings.JsonDataFileName));
            try
            {
                fileInfo.WriteAllText(jsonData);
            }
            catch (Exception)
            {
                throw new ProblemDetailsFileCreationException(fileInfo.ExtensionName);
            }
            return new DisposableFile(fileInfo);
        }
    }
}