using System;
using System.Linq.Expressions;
using CesarBmx.Shared.Domain.Models;

namespace CesarBmx.Shared.Domain.Expressions
{
    public static class AuditLogExpression
    {
        public static Expression<Func<AuditLog, bool>> AuditLog(string entity, DateTime createdAt)
        {
            return x => x.Entity == entity && x.CreatedAt <= createdAt;
        }
    }
}
