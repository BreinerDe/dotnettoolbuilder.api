using Dotnet.ToolBuilder.Api.Models;

namespace Dotnet.ToolBuilder.Api.Services.JsonFileCreator
{
    public interface IJsonFileCreatorService
    {
        DisposableFile CreateJsonFrom(Models.DotNetTool model);
    }
}