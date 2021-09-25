using System;
using Common.Helper;

namespace Common.Logging
{
    public class LogEvent
    {
        public readonly DateTime Timestamp;
        public readonly LoggingLevels Severity;
        public readonly string LoggingMessage;
        public readonly Exception? Exception;
        public readonly object[] Properties;

        public LogEvent(LoggingLevels severity, string message, Exception? exception = null, params object[] objects)
        {
            GuardClauses.IsNotNull(message, nameof(message));

            Timestamp = DateTime.Now;
            Severity = severity;
            LoggingMessage = message;
            Exception = exception;
            Properties = objects;
        }
    }
}
