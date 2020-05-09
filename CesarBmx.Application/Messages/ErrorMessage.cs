

namespace CesarBmx.Application.Messages
{
    public static class ErrorMessage
    {
        // Authentication
        public const string Unauthorized = "You are unauthorized";
        public const string Forbidden = "You don't have rights to perform this action";
        public const string Required = "This field is required";

        // Validation
        public const string BadRequest = "The request is invalid";
        public const string ValidationFailed = "Validation failed";
        public const string NotFound = "The resource does not exist";
        public const string Conflict = "There is a conflict with the current state";
        public const string InternalServerError = "Internal Server Error";
       
    }
}