using System;
using CesarBmx.Shared.Serialization.Helpers;

namespace CesarBmx.Shared.Domain.Models
{
    public class AuditLog : IEntity
    {
        public string Id => AuditLogId.ToString();
        public Guid AuditLogId { get; private set; }
        public string Action { get; private set; }
        public string Entity { get; private set; }
        public string EntityId { get; private set; }
        public string Json { get; private set; }
        public DateTime Time { get; private set; }

        public AuditLog() { }
        public AuditLog(string action, object entity, string entityId, DateTime time)
        {
            var entityName = entity.GetType().Name;
            if (entityName == "List`1")
            {
                entityName = entity.GetType().GetGenericArguments()[0].Name + "List";
            }

            AuditLogId = Guid.NewGuid();
            Action = action;
            Entity = entityName;
            EntityId = entityId;
            Time = time;
            Json = JsonConvertHelper.SerializeObjectRaw(entity);
        }
        public T ModelJsonToObject<T>()
        {
            return JsonConvertHelper.DeserializeObjectRaw<T>(Json);
        }
    }
}
