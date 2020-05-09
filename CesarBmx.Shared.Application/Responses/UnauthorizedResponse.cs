


namespace CesarBmx.Shared.Application.Responses
{
    public class UnauthorizedResponse : ErrorResponse
    {
        public UnauthorizedResponse(string code, string message)
            : base(code, 401, message)
        { }
    }
}