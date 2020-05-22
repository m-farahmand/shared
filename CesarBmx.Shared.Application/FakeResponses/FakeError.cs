using System.Collections.Generic;
using CesarBmx.Shared.Application.Responses;


namespace CesarBmx.Shared.Application.FakeResponses
{
    public static class FakeError
    {
        public static BadRequest GetFake_BadRequest()
        {
          
            return new BadRequest(nameof(Messages.ErrorMessage.BadRequest), Messages.ErrorMessage.BadRequest);
        }
        public static NotFound GetFake_NotFound()
        {
            return new NotFound(nameof(Messages.ErrorMessage.NotFound), Messages.ErrorMessage.NotFound);
        }
        public static Conflict GetFake_Conflict()
        {
            return new Conflict(nameof(Messages.ErrorMessage.Conflict), Messages.ErrorMessage.Conflict);
        }
        public static ValidationFailed GetFake_Validation()
        {
            var validationErrorResponseList = new List<ValidationError>
            {
                new ValidationError("Code", "FieldName", "Validation description")
            };
            var validationResponse = new ValidationFailed(nameof(Messages.ErrorMessage.ValidationFailed), Messages.ErrorMessage.ValidationFailed, validationErrorResponseList);

            return validationResponse;
        }
        public static InternalServerError GetFake_InternalServerError()
        {
            return new InternalServerError(nameof(Messages.ErrorMessage.InternalServerError), Messages.ErrorMessage.InternalServerError);
        }
        public static Unauthorized GetFake_Unauthorized()
        {
            return new Unauthorized(nameof(Messages.ErrorMessage.Unauthorized), Messages.ErrorMessage.Unauthorized);
        }
        public static Forbidden GetFake_Forbidden()
        {
            return new Forbidden(nameof(Messages.ErrorMessage.Forbidden), Messages.ErrorMessage.Forbidden);
        }
    }
}
