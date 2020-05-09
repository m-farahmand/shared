﻿using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CesarBmx.Api.Helpers
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder ConfigurePinnacleLogging(this IHostBuilder hostBuilder)
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