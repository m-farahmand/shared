


namespace CesarBmx.Shared.Domain.Models
{
    public interface IEntity<T> 
    {
        string Id { get; }
        T Update(T t);
    }
}
