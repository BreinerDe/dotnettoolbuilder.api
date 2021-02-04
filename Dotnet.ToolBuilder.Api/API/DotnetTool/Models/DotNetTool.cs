
namespace Dotnet.ToolBuilder.Api.API.DotnetTool
{
    public class DotNetTool
    {
        public DotNetTool(string projectName, DotNetToolName dotNetToolName, CommandInfo parameterInfo)
        {
            ProjectName = projectName;
            DotNetToolName = dotNetToolName;
            ParameterInfo = parameterInfo;
        }

        public string ProjectName { get; init;}

        public DotNetToolName DotNetToolName { get; init;}

        public CommandInfo ParameterInfo { get; init;}
    }
}
