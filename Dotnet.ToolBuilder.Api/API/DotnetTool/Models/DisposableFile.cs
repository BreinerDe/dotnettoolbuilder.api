using System.IO;
using FileSystem.Abstraction;

namespace Dotnet.ToolBuilder.Api.API.DotnetTool
{
    public sealed record DisposableFile(IFileInfo FileInfo) : DisposableObject
    {
        protected override void DisposeManagedResources()
        {
            Directory.Delete(FileInfo.Directory.FullName, true);
        }
    }
}