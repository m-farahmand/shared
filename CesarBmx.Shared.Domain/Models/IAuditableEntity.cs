


using System;

namespace CesarBmx.Shared.Domain.Models
{
    public interface IAuditableEntity
    {
        string Id { get; }
        DateTime Time { get; }
    }
}
