
namespace Dotnet.ToolBuilder.Api.API.DotnetTool
{
    public class OptionInfo : InfoBase
    {
        public string Alias { get; init; }

        public string Description { get; init;}

        public bool IsIsRequired { get; init;}

        public ArgumentInfo Argument { get; init;}
    }
}
