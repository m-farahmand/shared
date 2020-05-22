using CesarBmx.Shared.Application.FakeResponses;
using CesarBmx.Shared.Application.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace CesarBmx.Shared.Api.ResponseExamples
{
    public class ValidationFailedExample : IExamplesProvider<ValidationFailed>
    {
        public ValidationFailed GetExamples()
        {
            return FakeError.GetFake_Validation();
        }
    }
}