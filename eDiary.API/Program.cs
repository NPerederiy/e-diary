using Microsoft.Owin.Hosting;
using System;

namespace eDiary.API
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:8080"))
            {
                Console.WriteLine("Local server is running.");
                Console.WriteLine("Press any key to quit.");
                Console.ReadKey();
            }
        }
    }
}
