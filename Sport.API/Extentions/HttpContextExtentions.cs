using Sport.DataTransfer.Responses;

namespace Sport.API.Extentions
{
    public static class HttpContextExtentions
    {
        public static Task HandleErrorResponseAsync(this HttpContext context,ErrorResult errorResult) 
        {
            context.Response.ContentType = "application/json";

            if (errorResult.StatusCode.HasValue)
            {
                context.Response.StatusCode= errorResult.StatusCode.Value;
            }
            return context.Response.WriteAsync(errorResult.ToString());
        }
    }
}
