using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CesarBmx.Shared.Domain.Models;

namespace CesarBmx.Shared.Persistence.Repositories
{
    public interface IRepository<TEntity> where TEntity: IAuditableEntity
    {
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetSingle(object id);
        Task<TEntity> GetSingle(Expression<Func<TEntity, bool>> expression);
        void Add(TEntity entity);
        void AddRange(List<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(List<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(List<TEntity> entities);
        void UpdateCollection(List<TEntity> currentEntities, List<TEntity> newEntities);
    }
}