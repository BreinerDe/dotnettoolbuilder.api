using Dotnet.ToolBuilder.Api.ErrorHandling;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.ToolBuilder.Api.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddSingletonOption<T>(this IServiceCollection serviceCollection, IConfiguration configuration) where T : class
        {
            var settings = configuration.GetSetting<T>();
            if (settings == null)
            {
                throw new ProblemDetailsException(StatusCodes.Status500InternalServerError, $"Setting of type: {typeof(T).Name} could not be found",
                    $"Please check your appsettings.json, or check if the name of your class '{typeof(T).Name}' mach the section name in your appsettings.json");
            }

            serviceCollection.AddSingleton(settings);
        }
    }
}