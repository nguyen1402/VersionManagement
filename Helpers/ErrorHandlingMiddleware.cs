using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SC.VersionManagement.Helpers
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger _logger;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            if (exception is SoftComNotFoundException) code = HttpStatusCode.NotFound;
            else if (exception is SoftComUnauthorizedException) code = HttpStatusCode.Unauthorized;
            else if (exception is SoftComException) code = HttpStatusCode.BadRequest;
            else if (exception is AutoMapperMappingException)
            {
                while (exception.InnerException != null) { exception = exception.InnerException; code = HttpStatusCode.BadRequest; }
            }

            var result = string.Empty;

            var errorCode = exception.Data[SoftComException.ErrorCode]?.ToString();

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            result = JsonConvert.SerializeObject(!string.IsNullOrEmpty(errorCode) ? new ErrorDetails(errorCode, exception.Message) : new ErrorDetails(exception.Message), jsonSerializerSettings);

            if (code >= HttpStatusCode.InternalServerError)
            {
                var errorMessage = exception.InnerException != null ? exception.InnerException.Message : exception.Message;
                _logger.LogInformation(result);
            }
            else
            {
                _logger.LogInformation(result);
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
