using Sport.API.Extentions;
using Sport.Business.Exceptions;
using Sport.DataTransfer.Responses;

namespace Sport.API.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) 
        {
            try
            {
                await _next(context);
            }
            catch (AppException ex) 
            {
                var errorResult = _createResult(ex,ex.StatusCode);
                await context.HandleErrorResponseAsync(errorResult);
            }
            catch(Exception ex) 
            {
                var errorResult = _createResult(ex,StatusCodes.Status500InternalServerError);
                await context.HandleErrorResponseAsync(errorResult);
            }
        }

        private static ErrorResult _createResult(Exception exception, int statusCodes) 
        {
            return new ErrorResult(exception.Message, statusCodes, exception.Data);
        }
    }
}
