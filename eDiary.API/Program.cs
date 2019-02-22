using eDiary.API.Util;
using Microsoft.Owin.Hosting;
using System;

namespace eDiary.API
{
    class Program
    {
        static void Main(string[] args)
        {
            NinjectKernel.SetupKernel();
            using (WebApp.Start<Startup>("http://localhost:8181"))
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Local server is running.");
                Console.WriteLine("Press any key to quit.\n");
                Console.ReadKey();
            }
        }

    }
}
