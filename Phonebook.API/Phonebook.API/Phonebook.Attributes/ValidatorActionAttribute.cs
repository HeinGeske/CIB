using Phonebook.Models.ApiResponse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Phonebook.Attributes
{
    public class ValidatorActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.ModelState.IsValid)
            {
                filterContext.Result = new BadRequestObjectResult(
                    new ApiResponseModel<List<string>>()
                    {
                        Message = "Request failed validation",
                        Result = filterContext.ModelState.Values.SelectMany(x => x.Errors.Select(y => y.ErrorMessage)).ToList(),
                        StatusCode = (int)HttpStatusCode.BadRequest,
                    }
                    );
            }
        }
    }
}
