using CesarBmx.Shared.Application.FakeResponses;
using CesarBmx.Shared.Application.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace CesarBmx.Shared.Api.ResponseExamples
{
    public class ForbiddenExample : IExamplesProvider<Forbidden>
    {
        public Forbidden GetExamples()
        {
            return FakeError.GetFake_Forbidden();
        }
    }
}