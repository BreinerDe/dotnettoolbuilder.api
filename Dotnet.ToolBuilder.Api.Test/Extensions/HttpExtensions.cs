using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet.ToolBuilder.Api.Test.Extensions
{
    internal static class HttpExtensions
    {
        internal static Task<HttpResponseMessage> PostAsJsonStringAsync(this HttpClient httpClient, string url, string jsonContent)
        {
            return httpClient.PostAsync(url, new StringContent(jsonContent, Encoding.UTF8, MediaTypeNames.Application.Json));
        }
    }
}