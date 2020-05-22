


namespace CesarBmx.Shared.Application.Responses
{
    public class Unauthorized : Error
    {
        public Unauthorized(string code, string message)
            : base(code, 401, message)
        { }
    }
}