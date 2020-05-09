using Hangfire;
using Hangfire.Dashboard;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using CesarBmx.Shared.Api.ActionFilters;

namespace CesarBmx.Shared.Api.Configuration
{
    public static class HangfireConfig
    {
        public static IServiceCollection ConfigurePinnacleHangfire(this IServiceCollection services)
        {
            // Return
            return services;
        }
        public static IApplicationBuilder ConfigurePinnacleHangfire(this IApplicationBuilder app, bool enableBasicAuthentication = true)
        {
            // Configure
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { enableBasicAuthentication ? (IDashboardAuthorizationFilter)new HangfireBasicAuthorization() : new HangfireNonAuthorization() }
            });
            app.UseHangfireServer();


            return app;
        }
    }
}
