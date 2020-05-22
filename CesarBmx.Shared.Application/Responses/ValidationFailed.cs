using System.Collections.Generic;


namespace CesarBmx.Shared.Application.Responses
{
    public class ValidationFailed : Error
    {
        public List<ValidationError> ValidationErrors { get; set; }

        public ValidationFailed(string code, string message, List<ValidationError> validationErrors)
        : base(code, 422, message)
        {
            ValidationErrors = validationErrors;
        }
    }
}