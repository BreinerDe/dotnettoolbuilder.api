using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet.ToolBuilder.Api.API.DotnetTool
{
    [ApiController]
    public class DotnetToolBuilderController : ControllerBase
    {
        private readonly DotnetToolBuilderService dotnetToolBuilderService;

        public DotnetToolBuilderController(DotnetToolBuilderService dotnetToolBuilderService)
        {
            this.dotnetToolBuilderService = dotnetToolBuilderService;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create(DotNetTool toolData)
        {
            return File(await dotnetToolBuilderService.GetDotnetToolAsync(toolData).ConfigureAwait(false), MediaTypeNames.Application.Octet, toolData.ProjectName + ".zip");
        }

        [HttpPost("Create-Unsafe")]
        public async Task<ActionResult> CreateUnsafe(DotNetTool toolData)
        {
            return File(await dotnetToolBuilderService.GetDotnetToolAsync(toolData, "-fm").ConfigureAwait(false), MediaTypeNames.Application.Octet, toolData.ProjectName + ".zip");
        }
    }
}