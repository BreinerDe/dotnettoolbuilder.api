using System.Net.Mime;
using System.Threading.Tasks;
using Dotnet.ToolBuilder.Api.Services.DotnetToolBuilder;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet.ToolBuilder.Api.API.DotnetTool
{
    [ApiController]
    [Route("[controller]")]
    public class DotnetToolBuilderController : Controller
    {
        private readonly DotnetToolBuilderService dotnetToolBuilderService;

        public DotnetToolBuilderController(DotnetToolBuilderService dotnetToolBuilderService)
        {
            this.dotnetToolBuilderService = dotnetToolBuilderService;
        }

        [HttpPost("Create")]
        public async Task<FileStreamResult> Create(Models.DotNetTool toolData)
        {
            return File(await dotnetToolBuilderService.GetDotnetToolAsync(toolData), MediaTypeNames.Application.Octet, toolData.ProjectName + ".zip");
        }
    }
}
