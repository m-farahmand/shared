using CesarBmx.Shared.Application.FakeResponses;
using CesarBmx.Shared.Application.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace CesarBmx.Shared.Api.ResponseExamples
{
    public class BadRequestResponseExample : IExamplesProvider<BadRequestResponse>
    {
        public BadRequestResponse GetExamples()
        {
            return ErrorFakeResponse.GetFake_BadRequest();
        }
    }
}