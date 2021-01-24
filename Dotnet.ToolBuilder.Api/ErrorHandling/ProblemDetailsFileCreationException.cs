using Dotnet.ToolBuilder.Api.ErrorHandling;
using Microsoft.AspNetCore.Http;

namespace Dotnet.ToolBuilder.Api.Services.JsonFileCreator
{
    public class ProblemDetailsFileCreationException : ProblemDetailsException
    {
        public ProblemDetailsFileCreationException(string fileType) :
            base(StatusCodes.Status500InternalServerError, "Error Creating File", $"Could not create {fileType}")
        {
        }
    }
}