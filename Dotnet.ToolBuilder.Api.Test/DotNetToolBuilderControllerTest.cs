using System.Text.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dotnet.ToolBuilder.Api.Test
{
    [TestClass]
    public class DotNetToolBuilderControllerTest
    {
        private Models.DotNetTool TestModel;

        [AssemblyInitialize]
        public void Init()
        {
            TestModel = JsonSerializer.Deserialize<Models.DotNetTool>("MyAwesomeTool.json");
        }

        [TestMethod]
        public void TestCreate()
        {
        }
    }
}
