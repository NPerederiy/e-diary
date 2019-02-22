using System;
using System.Net.Http;
using System.Web.Http.Controllers;

namespace eDiary.API.Filters
{
    public static class ActionDetails
    {
        public static readonly object locker = new object();

        public static void ShowDetails(HttpActionContext context)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Controller: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{context.ControllerContext.ControllerDescriptor.ControllerName} --> [");
            switch (context.Request.Method.Method)
            {
                case "GET":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case "POST":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "PUT":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "DELETE":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }
            Console.Write(context.Request.Method);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"] {context.ActionDescriptor.ActionName} --> ");
        }
    }
}
