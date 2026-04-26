using Serilog;
using StudentManagementSystem.Common;
using System.Net;

namespace StudentManagementSystem.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var statusCode = HttpStatusCode.InternalServerError;

                if (ex is KeyNotFoundException)
                    statusCode = HttpStatusCode.NotFound;
                else if (ex is UnauthorizedAccessException)
                    statusCode = HttpStatusCode.Unauthorized;
                else if (ex is ArgumentException)
                    statusCode = HttpStatusCode.BadRequest;

                Log.Error(ex, "Exception occurred while processing request");

                context.Response.StatusCode = (int)statusCode;

                await context.Response.WriteAsJsonAsync(
                    new ApiResponse<object>(
                        false,
                        ex.Message,
                        null
                    )
                );
            }
        }
    }
}