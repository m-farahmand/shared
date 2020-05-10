using ElmahCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using CesarBmx.Shared.Api.ActionFilters;

namespace CesarBmx.Shared.Api.Configuration
{
    public static class ElmahConfig
    {
        public static IServiceCollection ConfigureSharedElmah(this IServiceCollection services)
        {
            services.AddElmah(options =>
            {
                options.Filters.Add(new ElmahFilter());
            });

            // Return
            return services;
        }
        public static IApplicationBuilder ConfigureSharedElmah(this IApplicationBuilder app)
        {
            app.UseElmah();

            return app;
        }
    }
}
