using System;
using FileSystem.Abstraction;

namespace Dotnet.ToolBuilder.Api.API.DotnetTool
{
    public class DirectoryBuilder
    {
        private readonly IDirectoryService directoryService;

        public DirectoryBuilder(IDirectoryService directoryService)
        {
            this.directoryService = directoryService;
        }

        public IDirectoryInfo CreateFolderInCurrentDirectory()
        {
            return directoryService.CreateDirectory(Guid.NewGuid().ToString());
        }
    }
}
