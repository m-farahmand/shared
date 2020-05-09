


namespace CesarBmx.Application.Responses
{
    public class InternalServerErrorResponse : ErrorResponse
    {
        public InternalServerErrorResponse(string code, string message)
            : base(code, 500, message)
        { }
    }
}