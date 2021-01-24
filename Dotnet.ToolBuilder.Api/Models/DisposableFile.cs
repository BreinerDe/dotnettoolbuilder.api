using System;
using System.IO;
using FileSystem.Abstraction;

namespace Dotnet.ToolBuilder.Api.Models
{
    public class DisposableFile : IDisposable
    {
        public IFileInfo FileInfo { get; }

        public DisposableFile(IFileInfo fileInfo)
        {
            FileInfo = fileInfo;
        }

        private void ReleaseUnmanagedResources()
        {
            Directory.Delete(FileInfo.Directory.FullName, true);
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        ~DisposableFile()
        {
            ReleaseUnmanagedResources();
        }
    }
}