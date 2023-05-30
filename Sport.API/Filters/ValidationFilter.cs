using Microsoft.AspNetCore.Mvc.Filters;
using Sport.DataTransfer.Responses;

namespace Sport.API.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
          
            if (!context.ModelState.IsValid)
            {             
                var resultModelState = context.ModelState.ToDictionary(kvp=>kvp.Key, kvp=>string.Join(" ",kvp.Value.Errors.Select(x=>x.ErrorMessage)));
                context.Result = new ValidationFailedResult(resultModelState);
                return;
            }

            await next();
            
        }
    }
}
