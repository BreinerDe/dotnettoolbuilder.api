using System;
using System.Threading.Tasks;
using Dotnet.ToolBuilder.Api.Test.Base;
using Dotnet.ToolBuilder.Api.Test.Extensions;
using DotNetTool.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dotnet.ToolBuilder.Api.Test.Api.DotnetTool
{
    [TestClass]
    public class ToolBuilderTest : TestBase
    {

        [ClassInitialize]
        public static async Task ClassInitialize(TestContext context)
        {
            var dotnetTool = DotNetToolFactory.Create();
            await dotnetTool.InstallAsync("dotnettool.builder", "9.0.0");
        }

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

        [ClassCleanup]
        public static async Task Cleanup()
        {
            var dotnetTool = DotNetToolFactory.Create();
            await dotnetTool.UninstallAsync("dotnettool.builder", "9.0.0");
        }
    }
}
