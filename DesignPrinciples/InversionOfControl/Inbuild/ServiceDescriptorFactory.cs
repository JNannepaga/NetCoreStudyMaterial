using Microsoft.Extensions.DependencyInjection;

namespace DemoConsoleApp.Inbuild
{
    public class ServiceDescriptorFactory
    {
        private static ServiceProvider _serviceProvider;
        
        public static T Service<T>()
        {
            return _serviceProvider.GetService<T>();
        }

        public static void Register()
        {
             _serviceProvider = new ServiceCollection()
            .AddSingleton<ILogger, Logger>()
            .BuildServiceProvider();
        }
    }
}
