using System.IO;

namespace Dotnet.ToolBuilder.Api.API.DotnetTool
{
    public class CleanupService
    {
        public void CleanUp(DotNetTool data)
        {
            //To be deleted when Toolbuilder is updated
            Directory.Delete(Path.Combine(Directory.GetCurrentDirectory(), data.ProjectName), true);
        }
    }
}