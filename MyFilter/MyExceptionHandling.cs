using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Lab3_MVC.MyFilter
{
    public class MyExceptionHandling : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {

                context.ExceptionHandled = true;
                context.Result = new ContentResult()
                {
                    Content = "content Admin"
                };


            }
            base.OnActionExecuted(context);
        }
    }
}
