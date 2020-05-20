using AutoMapper;
using CesarBmx.Shared.Application.Automapper;
using Microsoft.Extensions.DependencyInjection;

namespace CesarBmx.Shared.Api.Configuration
{
    public static class AutomapperConfig
    {
        public static IServiceCollection ConfigureSharedAutomapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AuditLogMapping).Assembly);

            return services;
        }
    }
}
