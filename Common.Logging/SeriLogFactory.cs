using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;
using System;

namespace Common.Logging
{
    public sealed class SeriLogFactory
    {
        private static Serilog.ILogger ConfigureLogger(ILoggerFactory loggerFactory)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile($"Serilog.json")
                .Build();

            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            loggerFactory.AddSerilog(logger);

            return logger;
        }

        public static Serilog.ILogger GetLogger()
        {
            var loggerFactory = new SerilogLoggerFactory();
            return ConfigureLogger(loggerFactory);
        }
    }
}
