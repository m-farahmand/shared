using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using CesarBmx.Shared.Domain.Builders;
using CesarBmx.Shared.Domain.Entities;

namespace CesarBmx.Shared.Persistence.Extensions
{
    public static class DbContextExtensions
    {
        public static void UpdateCollection<TEntity>(this DbContext dbContext, List<TEntity> currentEntities, List<TEntity> newEntities) where TEntity : class, IEntity
        {
            dbContext.AddRange(EntityBuilder.BuildEntitiesToAdd(currentEntities, newEntities));
            dbContext.UpdateRange(EntityBuilder.BuildEntitiesToUpdate(currentEntities, newEntities));
            dbContext.RemoveRange(EntityBuilder.BuildEntitiesToRemove(currentEntities, newEntities));
        }
    }
}
