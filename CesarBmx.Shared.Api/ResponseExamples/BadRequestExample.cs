using CesarBmx.Shared.Application.FakeResponses;
using CesarBmx.Shared.Application.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace CesarBmx.Shared.Api.ResponseExamples
{
    public class BadRequestExample : IExamplesProvider<BadRequest>
    {
        public BadRequest GetExamples()
        {
            return FakeError.GetFake_BadRequest();
        }
    }
}