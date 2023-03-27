using DemoConsoleApp.Inbuild;
using System;

namespace InversionOfControl
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ServiceDescriptorFactory.Register();
            Controller.Invoke();
        }
    }
}
