using System.IO;

namespace Dotnet.ToolBuilder.Api.Extensions
{
    public static class StreamExtensions
    {
        public static MemoryStream CopyToMemoryAndClose(this Stream stream)
        {
            var newStream = new MemoryStream();
            stream.CopyTo(newStream);
            stream.Close();
            newStream.Position = 0;
            return newStream;
        }
    }
}