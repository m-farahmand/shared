using CesarBmx.Shared.Application.FakeResponses;
using CesarBmx.Shared.Application.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace CesarBmx.Shared.Api.ResponseExamples
{ public class ConflictResponseExample : IExamplesProvider<ConflictResponse>
    {
        public ConflictResponse GetExamples()
        {
            return ErrorFakeResponse.GetFake_Conflict();
        }
    }
}