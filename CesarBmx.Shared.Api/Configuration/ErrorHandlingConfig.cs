using Microsoft.AspNetCore.Builder;
using CesarBmx.Shared.Api.Middlewares;

namespace CesarBmx.Shared.Api.Configuration
{
    public static class ErrorHandlingConfig
    {
        public static IApplicationBuilder ConfigureSharedErrorHandling(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();

            return app;
        }
    }
}
