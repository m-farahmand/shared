


namespace CesarBmx.Shared.Application.Responses
{
    public class Forbidden : Error
    {
        public Forbidden(string code, string message)
            : base(code, 403, message)
        { }
    }
}