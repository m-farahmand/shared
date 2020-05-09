using CesarBmx.Application.FakeResponses;
using CesarBmx.Application.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace CesarBmx.Api.ResponseExamples
{
    public class BadRequestExample : IExamplesProvider<BadRequestResponse>
    {
        public BadRequestResponse GetExamples()
        {
            return ErrorFakeResponse.GetFake_BadRequest();
        }
    }
    public class NotFoundExample : IExamplesProvider<NotFoundResponse>
    {
        public NotFoundResponse GetExamples()
        {
            return ErrorFakeResponse.GetFake_NotFound();
        }
    }
    public class ConflictExample : IExamplesProvider<ConflictResponse>
    {
        public ConflictResponse GetExamples()
        {
            return ErrorFakeResponse.GetFake_Conflict();
        }
    }
    public class ValidationFailedExample : IExamplesProvider<ValidationFailedResponse>
    {
        public ValidationFailedResponse GetExamples()
        {
            return ErrorFakeResponse.GetFake_Validation();
        }
    }
    public class InternalServerErrorExample : IExamplesProvider<InternalServerErrorResponse>
    {
        public InternalServerErrorResponse GetExamples()
        {
            return ErrorFakeResponse.GetFake_InternalServerError();
        }
    }
    public class UnauthorizedExample : IExamplesProvider<UnauthorizedResponse>
    {
        public UnauthorizedResponse GetExamples()
        {
            return ErrorFakeResponse.GetFake_Unauthorized();
        }
    }
    public class ForbiddenErrorExample : IExamplesProvider<ForbiddenResponse>
    {
        public ForbiddenResponse GetExamples()
        {
            return ErrorFakeResponse.GetFake_Forbidden();
        }
    }
}