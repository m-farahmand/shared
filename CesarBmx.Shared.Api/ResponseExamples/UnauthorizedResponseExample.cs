using CesarBmx.Shared.Application.FakeResponses;
using CesarBmx.Shared.Application.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace CesarBmx.Shared.Api.ResponseExamples
{
    public class UnauthorizedResponseExample : IExamplesProvider<UnauthorizedResponse>
    {
        public UnauthorizedResponse GetExamples()
        {
            return ErrorFakeResponse.GetFake_Unauthorized();
        }
    }
}