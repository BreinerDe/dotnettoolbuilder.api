using System.Collections.Generic;

namespace Dotnet.ToolBuilder.Api.API.DotnetTool
{
    public class CommandInfo : InfoBase
    {
        public IEnumerable<CommandInfo> SubCommands { get; init; }

        public IEnumerable<OptionInfo> Options { get; init; }

        public ArgumentInfo Argument { get; init; }

        public string Description { get; init; }
    }
}
