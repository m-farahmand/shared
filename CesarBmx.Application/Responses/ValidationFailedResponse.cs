using System.Collections.Generic;


namespace CesarBmx.Application.Responses
{
    public class ValidationFailedResponse : ErrorResponse
    {
        public List<ValidationErrorResponse> ValidationErrors { get; set; }

        public ValidationFailedResponse(string code, string message, List<ValidationErrorResponse> validationErrors)
        : base(code, 422, message)
        {
            ValidationErrors = validationErrors;
        }
    }
}