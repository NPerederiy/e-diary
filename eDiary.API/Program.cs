using eDiary.API.Util;
using Microsoft.Owin.Hosting;
using System;

namespace eDiary.API
{
    class Program
    {
        private const string serverURI = "http://localhost:8181";

        static void Main(string[] args)
        {
            NinjectKernel.SetupKernel();
            using (WebApp.Start<Startup>(serverURI))
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Local server is listening on {serverURI}");
                Console.WriteLine("Press any key to stop it.\n");
                Console.ReadKey();
            }
        }

    }
}
