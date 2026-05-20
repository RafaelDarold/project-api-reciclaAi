using project_api_reciclaAi.Exceptions;
using System.Net;
using System.Text.Json;

namespace project_api_reciclaAi.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
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
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = exception switch
            {
                NotFoundException => HttpStatusCode.NotFound,
                UnauthorizedException => HttpStatusCode.Unauthorized,
                BusinessException => HttpStatusCode.UnprocessableEntity,
                ConflictException => HttpStatusCode.Conflict,
                _ => HttpStatusCode.InternalServerError
            };

            var response = new
            {
                statusCode = (int)statusCode,
                message = exception.Message,
                timestamp = DateTime.UtcNow
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
