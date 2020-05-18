using System;
using Hangfire.Logging;

namespace CesarBmx.Shared.Api.Helpers
{
    public class HangfireLoggerProvider : ILogProvider
    {
        public ILog GetLogger(string name)
        {
            return new NoLogger();
        }

        public class NoLogger : ILog
        {
            public bool Log(LogLevel logLevel, Func<string> messageFunc, Exception exception)
            {
                return false;
            }
        }
    }
}