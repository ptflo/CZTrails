using System.Net;

namespace CZTrails.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger logger;
        private readonly RequestDelegate next;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex) //handles any exception in the project
            {
                var errorId = Guid.NewGuid();
                //log the exception
                logger.LogError(ex, $"{errorId}: {ex.Message}");

                //return custom err response
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var error = new
                {
                    Id = errorId,
                    ErrorMessage = "Něco se pokazilo! Pracujeme na tom." //zprava pro uzivatele
                };
                await httpContext.Response.WriteAsJsonAsync(error);
            }
        }
    }
}
