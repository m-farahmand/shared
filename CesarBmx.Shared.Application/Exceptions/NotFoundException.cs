

namespace CesarBmx.Shared.Application.Exceptions
{
    public class NotFoundException : DomainException
    {
        public NotFoundException(string message) : base(message)
        {}
    }
}
