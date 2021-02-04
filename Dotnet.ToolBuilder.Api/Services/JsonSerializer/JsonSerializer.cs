namespace Dotnet.ToolBuilder.Api.Services.JsonSerializer
{
    public class JsonSerializer : IJsonSerializer
    {
        public string Serialize<T>(T data) where T : class
        {
            return System.Text.Json.JsonSerializer.Serialize(data);
        }
    }
}