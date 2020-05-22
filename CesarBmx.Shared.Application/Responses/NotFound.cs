


namespace CesarBmx.Shared.Application.Responses
{

    public class NotFound : Error
    {
        public NotFound(string code, string message)
            : base(code, 404, message)
        { }
    }
}