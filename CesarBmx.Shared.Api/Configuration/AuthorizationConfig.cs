using System;
using Microsoft.Extensions.DependencyInjection;


namespace CesarBmx.Shared.Api.Configuration
{
    public static class AuthorizationConfig
    {
        public static IServiceCollection UseSharedAuthorization(this IServiceCollection services, Type permissions)
        {
            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = options.DefaultPolicy;

                foreach (var p in permissions.GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public))
                {
                    var permission = p.GetValue(null)?.ToString(); // static classes cannot be instanced, so use null...

                    // Add as many policies as permissions
                    options.AddPolicy(permission ?? throw new InvalidOperationException() , policy =>
                    {
                        policy.RequireAuthenticatedUser();
                        policy.RequireClaim("permission", permission);
                    });
                }
            });

            return services;
        }
    }
}