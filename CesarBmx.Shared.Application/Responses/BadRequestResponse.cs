


namespace CesarBmx.Shared.Application.Responses
{

    public class BadRequestResponse : ErrorResponse
    {
        public BadRequestResponse(string code, string message)
        : base(code, 400, message)
        { }
    }
}