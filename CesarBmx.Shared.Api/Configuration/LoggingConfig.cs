using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CesarBmx.Shared.Api.Configuration
{
    public static class LoggingConfig
    {
        public static IHostBuilder ConfigureSharedLogging(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureLogging(logging =>
            {
                logging.AddFilter("Default", LogLevel.Information);
                logging.AddFilter("System", LogLevel.None);
                logging.AddFilter("Microsoft", LogLevel.None);
                logging.AddFilter("Hangfire", LogLevel.None);
            });

            return hostBuilder;
        }
    }
}
