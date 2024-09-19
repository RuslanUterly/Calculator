using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Persistance.Models;

namespace Infrastructure;

public class NegativeNumberFilter : Attribute, IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        object operation = context.ActionArguments["operation"];

        if (operation is PowerRequest request)
        {

            if ((request.BaseValue < 0))
            {
                context.Result = new BadRequestObjectResult("Нельзя произвести операцию с числом меньше нуля");
                return;
            }
        }
    }
}
