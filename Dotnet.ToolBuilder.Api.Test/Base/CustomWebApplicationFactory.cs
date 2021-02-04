﻿using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace Dotnet.ToolBuilder.Api.Test.Base
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            var testAppsettingsJson = Path.Combine(Environment.CurrentDirectory, "appsettings.test.json");

            builder.ConfigureAppConfiguration((_, configurationBuilder) => configurationBuilder.AddJsonFile(testAppsettingsJson));

            builder.ConfigureServices(services =>
            {
                // if we need to switch between services we have to do it here
            });
        }
    }
}
