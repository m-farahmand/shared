


using System;

namespace CesarBmx.Shared.Domain.Entities
{
    public interface IEntity
    {
        string Id { get; }
        DateTime Time { get; }
    }
}
