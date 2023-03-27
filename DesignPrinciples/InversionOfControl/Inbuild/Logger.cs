using System;

namespace DemoConsoleApp.Inbuild
{
    public class Logger : ILogger
    {
        public void LogError(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
