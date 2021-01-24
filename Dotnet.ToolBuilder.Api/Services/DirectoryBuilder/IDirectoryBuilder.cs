using FileSystem.Abstraction;

namespace Dotnet.ToolBuilder.Api.Services.DirectoryBuilder
{
    public interface IDirectoryBuilder
    {
        IDirectoryInfo CreateFolderInCurrentDirectory();
    }
}