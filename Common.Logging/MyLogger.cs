using Serilog;

namespace Common.Logging
{
    //This is specific implementation for the logging framework we want to use.
    public class MyLogger : IMyLogger
    {
        //This variable shall keep the instance of Actual Logger in this case serilog. In case we have to implement any other logger then only change needs to be in this class.
        public readonly ILogger ActualLogger;
        public void AddLog(LogEvent logEvent)
        {
            switch (logEvent.Severity)
            {
                case LoggingLevels.Verbose:
                    ActualLogger.Verbose(logEvent.LoggingMessage, logEvent.Properties);
                    break;
                case LoggingLevels.Debug:
                    ActualLogger.Debug(logEvent.LoggingMessage, logEvent.Properties);
                    break;
                case LoggingLevels.Information:
                    ActualLogger.Information(logEvent.LoggingMessage, logEvent.Properties);
                    break;
                case LoggingLevels.Warning:
                    ActualLogger.Warning(logEvent.LoggingMessage, logEvent.Properties);
                    break;
                case LoggingLevels.Error:
                    ActualLogger.Error(logEvent.Exception, logEvent.LoggingMessage, logEvent.Properties);
                    break;
                case LoggingLevels.Fatal:
                    ActualLogger.Fatal(logEvent.Exception, logEvent.LoggingMessage, logEvent.Properties);
                    break;
                default:
                    ActualLogger.Fatal(logEvent.Exception, logEvent.LoggingMessage, logEvent.Properties);
                    break;
            }
        }

        public MyLogger(ILogger logger)
        {
            ActualLogger = logger;
        }
    }
}
