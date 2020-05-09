


namespace CesarBmx.Application.Responses
{
    public class ForbiddenResponse : ErrorResponse
    {
        public ForbiddenResponse(string code, string message)
            : base(code, 403, message)
        { }
    }
}