


namespace CesarBmx.Shared.Application.Responses
{
    public abstract class Error
    {
        public string Code { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }

        public Error(string code, int status, string message)
        {
            Code = code;
            Status = status;
            Message = message;
        }
    }
}