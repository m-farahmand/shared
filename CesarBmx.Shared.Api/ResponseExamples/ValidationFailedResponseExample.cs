using CesarBmx.Shared.Application.FakeResponses;
using CesarBmx.Shared.Application.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace CesarBmx.Shared.Api.ResponseExamples
{
    public class ValidationFailedResponseExample : IExamplesProvider<ValidationFailedResponse>
    {
        public ValidationFailedResponse GetExamples()
        {
            return ErrorFakeResponse.GetFake_Validation();
        }
    }
}