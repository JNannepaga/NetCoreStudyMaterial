
namespace DemoConsoleApp.Inbuild
{
    public class ServiceHandler
    {
        private readonly ILogger _logger;

        public ServiceHandler()
            : this(null)
        {

        }

        public ServiceHandler(ILogger logger)
        {
            _logger = logger ?? ServiceDescriptorFactory.Service<ILogger>();
        }

        public void Invoke()
        {
            _logger.LogError("---I'm started---");
            
            _logger.LogError("---I'm Ended---");
        }
    }
}
