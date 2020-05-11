using System;
using System.Linq.Expressions;
using CesarBmx.Shared.Domain.Entities;

namespace CesarBmx.Shared.Domain.Expressions
{
    public static class LogExpression
    {
        public static Expression<Func<Log, bool>> AuditLog(string entity, DateTime createdAt)
        {
            return x => x.Entity == createdAt && x.CreatedAt <= createdAt;
        }
    }
}
