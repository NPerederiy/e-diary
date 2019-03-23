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
            if (context.Exception is AggregateException)
            {
                LogError(context, GetExceptionMessages(context.Exception as AggregateException));
                context.Response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    ReasonPhrase = context.Exception.InnerException.Message
                };
            }
            else
            {
                var message = $"{context.Exception.Message}\n";
                if (context.Exception.InnerException != null)
                {
                    message = GetInnerExceptions(message, context.Exception.InnerException);
                }
                LogError(context, message);
                context.Response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    //ReasonPhrase = context.Exception.Message
                };
            }

            context.Exception = null;
        }

        private static void LogError(HttpActionExecutedContext context, string exceptionMessage)
        {
            lock (ActionDetails.locker)
            {
                ActionDetails.ShowDetails(context.ActionContext);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {exceptionMessage}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private string GetExceptionMessages(AggregateException exception)
        {
            var output = $"{exception.Message}\n"; ;
            foreach(var ex in exception.InnerExceptions)
            {
                output = GetInnerExceptions(output, ex);
            }
            return output;
        }

        private static string GetInnerExceptions(string output, Exception ex)
        {
            output += $"Inner exception: {ex.Message}\n";
            if (ex.InnerException != null)
            {
                output = GetInnerExceptions(output, ex.InnerException);
            }
            return output;
        }
    }
}
