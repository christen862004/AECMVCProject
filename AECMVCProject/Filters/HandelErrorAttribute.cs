using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AECMVCProject.Filters
{
    public class HandelErrorAttribute : Attribute,IExceptionFilter 
    {
        public void OnException(ExceptionContext context)
        {
            //ContentResult result=new ContentResult();
            //result.Content = "Some Exception thow";
            //context.Result = result;

            ViewResult result=new ViewResult();
            result.ViewName = "Error"; //Folder inside Views Folder
            context.Result = result;
        }
    }
}
