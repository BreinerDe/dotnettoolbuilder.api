
namespace Dotnet.ToolBuilder.Api.Models
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
