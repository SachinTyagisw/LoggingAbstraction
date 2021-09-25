using System;
namespace Common.Logging
{
    public static class MyLoggerExtension
    {
        public static void LogVerbose(this IMyLogger myLogger, string message)
        {
            myLogger.AddLog(new LogEvent(LoggingLevels.Verbose, message));
        }

        public static void LogVerboseFormat(this IMyLogger myLogger, string message, params object[] objects)
        {
            myLogger.AddLog(new LogEvent(LoggingLevels.Verbose, message, null, objects));
        }

        public static void LogDebug(this IMyLogger myLogger, string message)
        {
            myLogger.AddLog(new LogEvent(LoggingLevels.Debug, message));
        }

        public static void LogDebugFormat(this IMyLogger myLogger, string message, params object[] objects)
        {
            myLogger.AddLog(new LogEvent(LoggingLevels.Debug, message, null, objects));
        }

        public static void LogInformation(this IMyLogger myLogger, string message)
        {
            myLogger.AddLog(new LogEvent(LoggingLevels.Information, message));
        }

        public static void LogInformationFormat(this IMyLogger myLogger, string message,
            params object[] objects)
        {
            myLogger.AddLog(new LogEvent(LoggingLevels.Information, message, null, objects));
        }

        public static void LogWarning(this IMyLogger myLogger, string message)
        {
            myLogger.AddLog(new LogEvent(LoggingLevels.Warning, message));
        }

        public static void LogWarningFormat(this IMyLogger myLogger, string message, params object[] objects)
        {
            myLogger.AddLog(new LogEvent(LoggingLevels.Warning, message, null, objects));
        }

        public static void LogError(this IMyLogger myLogger, string message)
        {
            myLogger.AddLog(new LogEvent(LoggingLevels.Error, message));
        }

        public static void LogErrorFormat(this IMyLogger myLogger, string message, params object[] objects)
        {
            myLogger.AddLog(new LogEvent(LoggingLevels.Error, message, null, objects));
        }

        public static void LogFatal(this IMyLogger myLogger, string message)
        {
            myLogger.AddLog(new LogEvent(LoggingLevels.Fatal, message));
        }

        public static void LogFatalFormat(this IMyLogger myLogger, string message, params object[] objects)
        {
            myLogger.AddLog(new LogEvent(LoggingLevels.Fatal, message, null, objects));
        }

        public static void LogException(this IMyLogger myLogger, Exception exception)
        {
            var e = exception;
            while (e != null)
            {
                myLogger.Log(e);
                e = e.InnerException;
            }
        }

        public static void LogExceptionFormat(this IMyLogger myLogger, Exception exception, params object[] objects)
        {
            myLogger.AddLog(new LogEvent(LoggingLevels.Exception, exception.Message, exception, objects));
        }

        public static void Log(this IMyLogger myLogger, Exception exception)
        {
            myLogger.AddLog(new LogEvent(LoggingLevels.Error, exception.Message, exception));
        }
    }
}
