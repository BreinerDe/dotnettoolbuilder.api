using System;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet.ToolBuilder.Api.ErrorHandling
{
    public class ProblemDetailsException : Exception
    {
        public ProblemDetailsException(int statusCode, string title, string details) : base(title)
        {
            ProblemDetails = new ProblemDetails
            {
                Title = title,
                Detail = details,
                Status = statusCode
            };
        }
        internal ProblemDetails ProblemDetails { get; init;}
    }

}