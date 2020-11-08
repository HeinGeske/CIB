using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Phonebook.Helpers;
using Phonebook.Metrics;
using Phonebook.Models.ApiResponse;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Phonebook.Middleware
{
    public class ErrorHandlingMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleWare> _logger;
        public ErrorHandlingMiddleWare(RequestDelegate next, ILogger<ErrorHandlingMiddleWare> logger)
        {
            _next = next;

            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception e)
            {
                ApiMetrics.ApiCallExceptionCounter.Increment();
                _logger.LogError(e.Message);
                if (!context.Response.HasStarted)
                {
                    context.Response.ContentType = "application/json";
                    ApiResponseModel<string> response = new ApiResponseModel<string>()
                    {
                        Message = e.Message,
                        Result = "Failed",
                        StatusCode = (int)HttpStatusCode.BadRequest
                    };

                    string json = SerializeHelper.SerializeObject(response);
                    await context.Response.WriteAsync(json);
                }
            }
        }
    }
}