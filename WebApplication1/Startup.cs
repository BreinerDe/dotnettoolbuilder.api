using AspNetCore.Simple.Sdk.Startups;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace WebApplication1
{
    public class Startup : SimpleStartup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment) : base(configuration, webHostEnvironment, typeof(Startup).Assembly, new PathString("/api/core"), "Pulse Core API")
        {
        }
    }
}
