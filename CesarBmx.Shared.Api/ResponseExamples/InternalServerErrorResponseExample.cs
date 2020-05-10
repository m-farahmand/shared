using CesarBmx.Shared.Application.FakeResponses;
using CesarBmx.Shared.Application.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace CesarBmx.Shared.Api.ResponseExamples
{
    public class InternalServerErrorResponseExample : IExamplesProvider<InternalServerErrorResponse>
    {
        public InternalServerErrorResponse GetExamples()
        {
            return ErrorFakeResponse.GetFake_InternalServerError();
        }
    }
}