using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CesarBmx.Shared.Domain.ModelBuilders;
using CesarBmx.Shared.Domain.Models;
using CesarBmx.Shared.Domain.Expressions;

namespace CesarBmx.Shared.Persistence.Repositories
{
    public class AuditRepository<TEntity>: IRepository<TEntity> where TEntity: class, IAuditableEntity
    {
        protected readonly List<TEntity> List;
        private readonly Repository<AuditLog> _logRepository;

        public AuditRepository(Repository<AuditLog> logRepository)
        {
            List = new List<TEntity>();
            _logRepository = logRepository;
        }

        public AuditRepository<TEntity> LoadAudit(DateTime dateTime)
        {
            var auditLog = _logRepository.GetAll(AuditLogExpression.AuditLog(typeof(TEntity).Name, dateTime)).Result;

            foreach (var logEntry in auditLog)
            {
                TEntity originalValue;
                TEntity newValue;
                switch (logEntry.Action)
                {
                    case "Add":
                        newValue = logEntry.ModelJsonToObject<TEntity>();
                        List.Add(newValue);
                        break;
                    case "Update":
                        newValue = logEntry.ModelJsonToObject<TEntity>();
                        originalValue = GetSingle(newValue.Id).Result;
                        var index = List.IndexOf(originalValue);
                        if (index != -1) List[index] = newValue;
                        break;
                    case "Remove":
                        newValue = logEntry.ModelJsonToObject<TEntity>();
                        originalValue = GetSingle(newValue.Id).Result;
                        List.Remove(originalValue);
                        break;
                }
            }

            return this;
        }

        public Task<List<TEntity>> GetAll()
        {
            return Task.FromResult(List);
        }
        public Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression)
        {
            return Task.FromResult(List.Where(expression.Compile()).ToList());
        }
        public Task<TEntity> GetSingle(object id)
        {
            return Task.FromResult(List.FirstOrDefault(x=>x.Id == (string)id));
        }
        public Task<TEntity> GetSingle(Expression<Func<TEntity, bool>> expression)
        {
            return Task.FromResult(List.FirstOrDefault(expression.Compile()));
        }
        public void Add(TEntity entity)
        {
            List.Add(entity);
        }
        public void AddRange(List<TEntity> entities)
        {
            List.AddRange(entities);
        }
        public void Update(TEntity entity)
        {

        }
        public void UpdateRange(List<TEntity> entities)
        {
            
        }
        public void Remove(TEntity entity)
        {
            List.Remove(entity);
        }
        public void RemoveRange(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Remove(entity);
            }
        }
        public void UpdateCollection(List<TEntity> currentEntities, List<TEntity> newEntities)
        {
            AddRange(EntityBuilder.BuildEntitiesToAdd(currentEntities, newEntities));
            UpdateRange(EntityBuilder.BuildEntitiesToUpdate(currentEntities, newEntities));
            RemoveRange(EntityBuilder.BuildEntitiesToRemove(currentEntities, newEntities));
        }
    }
}
