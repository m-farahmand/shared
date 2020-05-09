using System.Collections.Generic;
using CesarBmx.Application.Messages;
using CesarBmx.Application.Responses;


namespace CesarBmx.Application.FakeResponses
{
    public static class ErrorFakeResponse
    {
        public static BadRequestResponse GetFake_BadRequest()
        {
          
            return new BadRequestResponse(nameof(ErrorMessage.BadRequest), ErrorMessage.BadRequest);
        }
        public static NotFoundResponse GetFake_NotFound()
        {
            return new NotFoundResponse(nameof(ErrorMessage.NotFound), ErrorMessage.NotFound);
        }
        public static ConflictResponse GetFake_Conflict()
        {
            return new ConflictResponse(nameof(ErrorMessage.Conflict), ErrorMessage.Conflict);
        }
        public static ValidationFailedResponse GetFake_Validation()
        {
            var validationErrorResponseList = new List<ValidationErrorResponse>
            {
                new ValidationErrorResponse("Code", "FieldName", "Validation description")
            };
            var validationResponse = new ValidationFailedResponse(nameof(ErrorMessage.ValidationFailed), ErrorMessage.ValidationFailed, validationErrorResponseList);

            return validationResponse;
        }
        public static InternalServerErrorResponse GetFake_InternalServerError()
        {
            return new InternalServerErrorResponse(nameof(ErrorMessage.InternalServerError), ErrorMessage.InternalServerError);
        }
        public static UnauthorizedResponse GetFake_Unauthorized()
        {
            return new UnauthorizedResponse(nameof(ErrorMessage.Unauthorized), ErrorMessage.Unauthorized);
        }
        public static ForbiddenResponse GetFake_Forbidden()
        {
            return new ForbiddenResponse(nameof(ErrorMessage.Forbidden), ErrorMessage.Forbidden);
        }
    }
}
