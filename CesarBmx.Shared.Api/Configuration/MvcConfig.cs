using System;
using CesarBmx.Shared.Api.ActionFilters;
using CesarBmx.Shared.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace CesarBmx.Shared.Api.Configuration
{
    public static class MvcConfig
    {
        public static IServiceCollection ConfigureSharedMvc(this IServiceCollection services, Type validator, bool enableRazorPages)
        {
            services.AddControllers(
                    config =>
                    {
                        // Authentication
                        var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
                            .Build();
                        config.Filters.Add(new AuthorizeFilter(policy));

                        // Filters
                        config.Filters.Add(typeof(ValidateRequestAttribute));
                        config.Filters.Add(typeof(IdentityFilter));
                    })
                .ConfigureFluentValidation(validator.Assembly)
                .ConfigureSharedSerialization();

            if(enableRazorPages) services.AddRazorPages();

            services.AddRouting(options => options.LowercaseUrls = true);

            // Allow synchronous IO (elmah css was not loading)
            services.Configure<IISServerOptions>(options => { options.AllowSynchronousIO = true; });
            services.Configure<KestrelServerOptions>(options => { options.AllowSynchronousIO = true; });

            services.AddControllers().AddApplicationPart(typeof(Z_VersionController).Assembly);

            return services;
        }

        public static IApplicationBuilder ConfigureSharedMvc(this IApplicationBuilder app, bool enableRazorPages)
        {
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                if (enableRazorPages) endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
            app.UseStaticFiles();

            return app;
        }
    }
}
