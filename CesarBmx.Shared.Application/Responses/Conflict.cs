


namespace CesarBmx.Shared.Application.Responses
{
    public class Conflict : Error
    {
        public Conflict(string code, string message)
            : base(code, 409, message)
        { }
    }
}