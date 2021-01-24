using System;
using System.IO;
using System.Linq;
using FileSystem.Abstraction;
using DirectoryInfo = System.IO.DirectoryInfo;

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
            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var directory = directoryService.CreateDirectory(Path.Combine(currentDirectory, Guid.NewGuid().ToString()));
            new DirectoryInfo(directory.FullName).GetFileSystemInfos().ToList().ForEach(x => x.Attributes = FileAttributes.Normal);
            return directory;
        }
    }
}
