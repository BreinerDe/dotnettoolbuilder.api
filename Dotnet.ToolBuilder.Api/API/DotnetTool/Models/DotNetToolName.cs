
namespace Dotnet.ToolBuilder.Api.API.DotnetTool
{
    public class DotNetToolName
    {
        public DotNetToolName(string name, string normalizedName)
        {
            Name = name;
            NormalizedName = normalizedName;
        }

        public string Name { get; init;}

        public string NormalizedName { get; init;}
    }
}
