using SimpleInjector;
using Serilog;

namespace Common.Logging
{
    public class RegisterLoggingModule
    {
        public static void Bootstrap(Container container)
        {
            container.RegisterSingleton<ILogger>(SeriLogFactory.GetLogger);
            container.RegisterSingleton(typeof(IMyLogger), typeof(MyLogger));
        }
    }
}
