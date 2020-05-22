


namespace CesarBmx.Shared.Application.Responses
{
    public class InternalServerError : Error
    {
        public InternalServerError(string code, string message)
            : base(code, 500, message)
        { }
    }
}