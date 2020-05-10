using CesarBmx.Shared.Application.FakeResponses;
using CesarBmx.Shared.Application.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace CesarBmx.Shared.Api.ResponseExamples
{ public class NotFoundResponseExample : IExamplesProvider<NotFoundResponse>
    {
        public NotFoundResponse GetExamples()
        {
            return ErrorFakeResponse.GetFake_NotFound();
        }
    }
}