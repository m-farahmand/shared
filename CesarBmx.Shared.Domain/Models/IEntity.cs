


using System;

namespace CesarBmx.Shared.Domain.Models
{
    public interface IEntity
    {
        string Id { get; }
        DateTime Time { get; }
    }
}
