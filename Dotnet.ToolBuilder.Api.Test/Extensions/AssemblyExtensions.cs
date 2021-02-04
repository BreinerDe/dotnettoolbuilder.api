using System.IO;
using System.Linq;
using System.Reflection;

namespace Dotnet.ToolBuilder.Api.Test.Extensions
{
    internal static class AssemblyExtensions
    {
        internal static string GetJsonStringOf(this object source, string embededResourceName)
        {
            return source.GetType().Assembly.GetJsonStringOf(embededResourceName);
        }


        internal static string GetJsonStringOf(this Assembly assembly, string embededResourceName)
        {
            var result = assembly.GetFileAsByteArrayFrom(embededResourceName);
            using var streamReader = new StreamReader(new MemoryStream(result.FileContent));
            return streamReader.ReadToEnd();
        }

        // very important try to avoid accessing file system during tests, so we fetch our data from
        // our assembly direct from the memory :-) 
        private static InMemoryFile GetFileAsByteArrayFrom(this Assembly assembly, string fileName)
        {
            var name = assembly.GetManifestResourceNames().First(name => name.Contains(fileName));
            using var stream = assembly.GetManifestResourceStream(name);
            using var ms = new MemoryStream();
            stream!.CopyTo(ms);
            return new InMemoryFile(ms.ToArray(), name);
        }
    }
}