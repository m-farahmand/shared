using CesarBmx.Shared.Application.FakeResponses;
using CesarBmx.Shared.Application.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace CesarBmx.Shared.Api.ResponseExamples
{
    public class ForbiddenErrorResponseExample : IExamplesProvider<ForbiddenResponse>
    {
        public ForbiddenResponse GetExamples()
        {
            return ErrorFakeResponse.GetFake_Forbidden();
        }
    }
}