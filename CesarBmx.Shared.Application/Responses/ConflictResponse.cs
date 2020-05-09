


namespace CesarBmx.Shared.Application.Responses
{
    public class ConflictResponse : ErrorResponse
    {
        public ConflictResponse(string code, string message)
            : base(code, 409, message)
        { }
    }
}