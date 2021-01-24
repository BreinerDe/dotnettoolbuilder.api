using DotNetTool.Service.Models;
using Microsoft.AspNetCore.Http;

namespace Dotnet.ToolBuilder.Api.ErrorHandling
{
    public class ResultCodeHandler
    {
        public void HandleDotNetToolBuilderResult(CliRunResult result)
        {
            if (result.ExitCode != 0)
            {
                throw new ProblemDetailsException(StatusCodes.Status500InternalServerError, "Dotnet Toolbuilder failed",
                    $"Exitcode {result.ExitCode}");
            }
        }
    }
}