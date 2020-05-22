


namespace CesarBmx.Shared.Application.Responses
{
    public class BadRequest : Error
    {
        public BadRequest(string code, string message)
        : base(code, 400, message)
        { }
    }
}