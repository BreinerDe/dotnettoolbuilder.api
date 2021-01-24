using System.IO;
using Dotnet.ToolBuilder.Api.Extensions;

namespace Dotnet.ToolBuilder.Api.Services.Stream
{
    public class StreamService
    {
        public MemoryStream ReadFileToMemoryStream(string fileName)
        {
            var file = File.OpenRead(fileName);
            return file.CopyToMemoryAndClose();
        }
    }
}
