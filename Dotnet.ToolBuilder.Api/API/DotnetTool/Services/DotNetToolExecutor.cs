using System.Threading.Tasks;
using AspNetCore.Simple.Sdk.ErrorHandling;
using DotNetTool.Service;
using Microsoft.AspNetCore.Http;

namespace Dotnet.ToolBuilder.Api.API.DotnetTool
{
    public class DotNetToolExecutor
    {
        private readonly DotnetToolBuilderSettings dotnetToolBuilderSettings;
        private readonly IDotNetTool dotNetTool;

        public DotNetToolExecutor(DotnetToolBuilderSettings dotnetToolBuilderSettings, IDotNetTool dotNetTool)
        {
            this.dotnetToolBuilderSettings = dotnetToolBuilderSettings;
            this.dotNetTool = dotNetTool;
        }
        internal async Task ExecuteAsync(string consoleParameter, DisposableFile jsonFile, string zipName)
        {
            var result = await dotNetTool.RunAsync(dotnetToolBuilderSettings.BaseCommand, $"-ff {jsonFile.FileInfo.FullName} {consoleParameter} -az {zipName}").ConfigureAwait(false);
            if (result.ExitCode != 0)
            {
                throw new ProblemDetailsException(StatusCodes.Status500InternalServerError, "Dotnet Toolbuilder failed",
                    $"Exitcode {result.ExitCode}");
            }
        }

    }
}