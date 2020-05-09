using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using CesarBmx.Shared.Persistence.Entities;

namespace CesarBmx.Shared.Persistence.Extensions
{
    public static class DbContextExtensions
    {
        public static void UpdateCollection<TEntity>(this DbContext dbContext, List<TEntity> currentEntities, List<TEntity> newEntities) where TEntity : class, IEntity
        {
            dbContext.AddRange(BuildEntitiesToAdd(currentEntities, newEntities));
            dbContext.UpdateRange(BuildEntitiesToUpdate(currentEntities, newEntities));
            dbContext.RemoveRange(BuildEntitiesToRemove(currentEntities, newEntities));
        }
        public static List<T> BuildEntitiesToAdd<T>(List<T> entities, List<T> newEntities) where T : class, IEntity
        {
            // Add those not found in the list
            var entitiesToAdd = new List<T>();
            foreach (var newEntity in newEntities)
            {
                if (entities.FirstOrDefault(x => x.Id == newEntity.Id) == null)
                    entitiesToAdd.Add(newEntity);
            }

            // Return
            return entitiesToAdd;
        }
        public static List<T> BuildEntitiesToUpdate<T>(List<T> entities, List<T> newEntities) where T : class, IEntity
        {
            // Update those found in the list
            var entitiesToUpdate = new List<T>();
            foreach (var newEntity in newEntities)
            {
                if (entities.FirstOrDefault(x => x.Id == newEntity.Id) != null)
                    entitiesToUpdate.Add(newEntity);
            }

            // Return
            return entitiesToUpdate;
        }
        public static List<T> BuildEntitiesToRemove<T>(List<T> entities, List<T> newEntities) where T : class, IEntity
        {
            // Remove those no longer in the list
            var entitiesToRemove = new List<T>();
            foreach (var entity in entities)
            {
                if (newEntities.FirstOrDefault(x => x.Id == entity.Id) == null)
                    entitiesToRemove.Add(entity);
            }

            // Return
            return entitiesToRemove;
        }
    }
}
