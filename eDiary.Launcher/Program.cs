using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace eDiary.Launcher
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:4200/";

            Console.WriteLine("eDiary is launching...");

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                var p = new Process();
                var info = new ProcessStartInfo
                {
                    WorkingDirectory = "c://",
                    FileName = "cmd.exe",
                    RedirectStandardInput = true,
                    UseShellExecute = false
                };

                p.StartInfo = info;
                p.Start();

                using (StreamWriter sw = p.StandardInput)
                {
                    if (sw.BaseStream.CanWrite)
                    {
                        sw.WriteLine($"start {url}");
                        //sw.WriteLine($"start {url}");
                        //sw.WriteLine($"start {url}");
                    }
                }
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Process.Start("xdg-open", url);
                // TODO: implement launch of the api
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Process.Start("open", url);
                // TODO: implement launch of the api
            }
            
            Console.WriteLine("Launched");
        }
    }
}
