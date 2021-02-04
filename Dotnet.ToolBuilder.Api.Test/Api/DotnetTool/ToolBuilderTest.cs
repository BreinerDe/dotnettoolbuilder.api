using System.Threading.Tasks;
using Dotnet.ToolBuilder.Api.API.DotnetTool;
using Dotnet.ToolBuilder.Api.Test.Base;
using Dotnet.ToolBuilder.Api.Test.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.ToolBuilder.Api.Test.Api.DotnetTool
{
    [TestClass]
    public class ToolBuilderTest : TestBase
    {
        [TestMethod]
        public async Task Should_return_Success_StatusCode()
        {
            var testTool = this.GetJsonStringOf("MyAwesomeTool.json");
            var result = await Client.PostAsJsonStringAsync("api/toolbuilder/create", testTool).ConfigureAwait(false);

            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        public async Task Unsafe_Should_return_Success_StatusCode()
        {
            var testTool = this.GetJsonStringOf("MyAwesomeTool.json");
            var result = await Client.PostAsJsonStringAsync("api/toolbuilder/create-unsafe", testTool).ConfigureAwait(false);

            Assert.IsTrue(result.IsSuccessStatusCode);
        }
    }
}
