


namespace CesarBmx.Application.Responses
{

    public class NotFoundResponse : ErrorResponse
    {
        public NotFoundResponse(string code, string message)
            : base(code, 404, message)
        { }
    }
}