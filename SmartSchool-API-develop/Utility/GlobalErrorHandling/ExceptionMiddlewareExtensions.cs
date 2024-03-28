using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using Utility.LoggerService;

namespace Utility.GlobalErrorHandling
{
    public class GlobalExceptionHandlerMiddleware
    {

        private readonly RequestDelegate _next;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new ApiResponse<string>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };

                switch (ex)
                {
                    case APIExceptions e:
                        responseModel.StatusCode =(int)HttpStatusCode.BadRequest; 
                        break;
                    default:
                        responseModel.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                
                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}
