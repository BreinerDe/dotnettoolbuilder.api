using System.Net.Http;

namespace Dotnet.ToolBuilder.Api.Test.Extensions
{
    internal static class InMemoryFileExtensions
    {
        internal static MultipartFormDataContent ToMultipartFormDataContent(this InMemoryFile source, string controllerParameterName)
        {
            var multiPartFormData = new MultipartFormDataContent();
            multiPartFormData.Add(new ByteArrayContent(source.FileContent), controllerParameterName, source.Name);
            multiPartFormData.Add(new StringContent("ResourceName"), "Estell-Test");

            return multiPartFormData;
        }
    }
}