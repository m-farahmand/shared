using CesarBmx.Shared.Application.FakeResponses;
using CesarBmx.Shared.Application.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace CesarBmx.Shared.Api.ResponseExamples
{ public class NotFoundExample : IExamplesProvider<NotFound>
    {
        public NotFound GetExamples()
        {
            return FakeError.GetFake_NotFound();
        }
    }
}