using CesarBmx.Shared.Application.FakeResponses;
using CesarBmx.Shared.Application.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace CesarBmx.Shared.Api.ResponseExamples
{ public class ConflictExample : IExamplesProvider<Conflict>
    {
        public Conflict GetExamples()
        {
            return FakeError.GetFake_Conflict();
        }
    }
}