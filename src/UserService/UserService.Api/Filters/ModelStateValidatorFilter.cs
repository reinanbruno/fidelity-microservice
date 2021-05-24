using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace UserService.Api.Filters
{
    public class ModelStateValidatorFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                object listErrors = new
                {
                    errors = context.ModelState.SelectMany(ms => ms.Value.Errors)
                                               .Select(e => e.ErrorMessage)
                                               .ToList()
                };

                context.Result = new BadRequestObjectResult(listErrors);
            }
        }
    }
}
