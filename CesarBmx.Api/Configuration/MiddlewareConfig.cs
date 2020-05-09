using Microsoft.AspNetCore.Builder;
using CesarBmx.Api.Middlewares;

namespace CesarBmx.Api.Configuration
{
    public static class MiddlewareConfig
    {
        public static IApplicationBuilder ConfigurePinnacleMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();

            return app;
        }
    }
}
