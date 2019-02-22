using System;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace eDiary.API.Filters
{
    public class ConsoleLogger : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext context)
        {
            lock(ActionDetails.locker)
            {
                ActionDetails.ShowDetails(context);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Executing...");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
            if (context.Exception == null)
            {
                lock (ActionDetails.locker)
                {
                    ActionDetails.ShowDetails(context.ActionContext);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Success");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
