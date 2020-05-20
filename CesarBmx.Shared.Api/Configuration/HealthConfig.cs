using CesarBmx.Shared.Application.Settings;
using HealthChecks.UI.Client;
using HealthChecks.UI.InMemory.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CesarBmx.Shared.Api.Configuration
{
    public static class HealthConfig
    {
        public static IServiceCollection ConfigureSharedHealth(this IServiceCollection services, IConfiguration configuration)
        {
            // Grab AppSettings
            var appSettings = new AppSettings();
            configuration.GetSection("AppSettings").Bind(appSettings);

            // Health checks
            services.AddHealthChecksUI(setupSettings: setup =>
            {
                setup.AddHealthCheckEndpoint(appSettings.ApplicationId, "/health");
                setup.SetEvaluationTimeInSeconds(60 * 10);
                setup.DisableDatabaseMigrations();
            }).AddInMemoryStorage();

            // Return
            return services;
        }
        public static IApplicationBuilder ConfigureSharedHealth(this IApplicationBuilder app)
        {
            // Api
            app.UseEndpoints(config =>
            {
                config.MapHealthChecks("/health", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            });

            // UI
            app.UseHealthChecksUI(setup =>
            {
                setup.ApiPath = "/health-ui-api";
                setup.UIPath = "/health-ui";
            });


            // Return
            return app;
        }
    }
}
