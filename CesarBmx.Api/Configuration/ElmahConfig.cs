using ElmahCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using CesarBmx.Api.ActionFilters;

namespace CesarBmx.Api.Configuration
{
    public static class ElmahConfig
    {
        public static IServiceCollection ConfigurePinnacleElmah(this IServiceCollection services)
        {
            services.AddElmah(options =>
            {
                options.Filters.Add(new ElmahFilter());
            });

            // Return
            return services;
        }
        public static IApplicationBuilder ConfigurePinnacleElmah(this IApplicationBuilder app)
        {
            app.UseElmah();

            return app;
        }
    }
}
