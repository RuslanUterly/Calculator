using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Persistance.Models;

namespace Infrastructure;

public class DevidedByZeroFilter : Attribute, IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        object operation = context.ActionArguments["operand"];

        if (operation is BaseOperationRequest request)
        {
            if (request.A == 0)
            {
                context.Result = new BadRequestObjectResult("Деление на ноль");
                return;
            }
        }
    }
}