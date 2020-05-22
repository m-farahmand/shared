using CesarBmx.Shared.Application.FakeResponses;
using CesarBmx.Shared.Application.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace CesarBmx.Shared.Api.ResponseExamples
{
    public class InternalServerErrorExample : IExamplesProvider<InternalServerError>
    {
        public InternalServerError GetExamples()
        {
            return FakeError.GetFake_InternalServerError();
        }
    }
}