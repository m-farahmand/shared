using Microsoft.Extensions.DependencyInjection;
using CesarBmx.Shared.Domain.Models;
using CesarBmx.Shared.Persistence.Repositories;

namespace CesarBmx.Shared.Api.Configuration
{
    public static class AuditConfigConfig
    {

        public static IServiceCollection AddAudit<TEntity>(
            this IServiceCollection services)
            where TEntity : class, IEntity
        {
            if (typeof(TEntity) == typeof(AuditLog))
            {
                services.AddScoped<Repository<TEntity>, Repository<TEntity>>();
                services.AddScoped<IRepository<TEntity>, Repository<TEntity>>();
                services.AddScoped<AuditRepository<TEntity>, AuditRepository<TEntity>>();
            }
            else
            {
                services.AddScoped<Repository<TEntity>, Repository<TEntity>>();
                services.AddScoped<IRepository<TEntity>, LoggerRepository<TEntity>>();
                services.AddScoped<AuditRepository<TEntity>, AuditRepository<TEntity>>();
            }

            // Return
            return services;
        }
    }
}
