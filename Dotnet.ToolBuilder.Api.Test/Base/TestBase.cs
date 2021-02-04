using System;
using System.Net.Http;
using AspNetCore.Simple.Sdk.Serializer.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dotnet.ToolBuilder.Api.Test.Base
{
    [TestClass]
    public abstract class TestBase
    {
        // We use assembly initialize to get better performance. But it is only possible if you change not states on the base
        // properties, otherwise we have to change to to clean up every test.
        //
        // Hint: With this 'AssemblyInitialize' the API is just started once.
        [AssemblyInitialize]
#pragma warning disable IDE0060 // Remove unused parameter => This parameter is part of the signature
        public static void AssemblyInitialize(TestContext testContext)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            // Create this with new, is not a fault, the reason is to keep the test class more cleaner.
            CustomWebApplicationFactory = new CustomWebApplicationFactory();
            ServiceProvider = CustomWebApplicationFactory.Services;
            Client = CustomWebApplicationFactory.CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false });
        }

        private static CustomWebApplicationFactory CustomWebApplicationFactory { get; set; } = null!;

        internal static IServiceProvider ServiceProvider { get; private set; } = null!;

        protected static HttpClient Client { get; private set; } = null!;

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            CustomWebApplicationFactory?.Dispose();
            Client?.Dispose();
        }
    }
}
