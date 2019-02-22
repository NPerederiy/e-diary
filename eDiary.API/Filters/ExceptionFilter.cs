using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace eDiary.API.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            //if (context.Exception is NotImplementedException)
            //{
            //    context.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            //}
            lock (ActionDetails.locker)
            {
                ActionDetails.ShowDetails(context.ActionContext);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {context.Exception.Message}");
                Console.ForegroundColor = ConsoleColor.White;
            }

            context.Response = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                ReasonPhrase = context.Exception.Message
            };
            context.Exception = null;
        }
    }
}
