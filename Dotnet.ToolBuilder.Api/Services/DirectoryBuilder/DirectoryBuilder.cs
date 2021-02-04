using System;
using System.IO;
using FileSystem.Abstraction;

namespace Dotnet.ToolBuilder.Api.Services.DirectoryBuilder
{
    public class DirectoryBuilder : IDirectoryBuilder
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
