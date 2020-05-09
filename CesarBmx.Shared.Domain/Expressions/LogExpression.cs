using System;
using System.Linq.Expressions;
using CesarBmx.Shared.Domain.Entities;

namespace CesarBmx.Shared.Domain.Expressions
{
    public static class LogExpression
    {
        public static Expression<Func<Log, bool>> AuditLog(string entity, DateTime dateTime)
        {
            return x => x.Entity == entity && x.Time <= dateTime;
        }
    }
}
