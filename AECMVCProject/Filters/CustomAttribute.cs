using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AECMVCProject.Filters
{
    //ResourceFilter()
    public class CustomAttribute : Attribute,IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Code
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //Code
        }
    }
}
