using CesarBmx.Shared.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using CesarBmx.Shared.Domain.Models;
using CesarBmx.Shared.Persistence.Repositories;

namespace CesarBmx.Shared.Api.Configuration
{
    public static class AuditConfigConfig
    {
        public static IServiceCollection AddAudit(this IServiceCollection services)
        {

            services.AddScoped<Repository<AuditLog>, Repository<AuditLog>>();
            services.AddScoped<IRepository<AuditLog>, Repository<AuditLog>>();
            services.AddScoped<AuditRepository<AuditLog>, AuditRepository<AuditLog>>();

            services.AddScoped<AuditLogService>();

            // Return
            return services;
        }
        public static IServiceCollection AddAuditRepository<TEntity>(
            this IServiceCollection services)
            where TEntity : class, IEntity
        {
            services.AddScoped<Repository<TEntity>, Repository<TEntity>>();
            services.AddScoped<IRepository<TEntity>, LoggerRepository<TEntity>>();
            services.AddScoped<AuditRepository<TEntity>, AuditRepository<TEntity>>();

            // Return
            return services;
        }
        public static IServiceCollection AddRepository<TEntity>(
            this IServiceCollection services)
            where TEntity : class, IEntity
        {
            services.AddScoped<Repository<TEntity>>();
            services.AddScoped<IRepository<TEntity>, Repository<TEntity>>();

            // Return
            return services;
        }
    }
}
