namespace Dotnet.ToolBuilder.Api.Services.JsonSerializer
{
    public interface IJsonSerializer
    {
        string Serialize<T>(T data) where T : class;
    }
}