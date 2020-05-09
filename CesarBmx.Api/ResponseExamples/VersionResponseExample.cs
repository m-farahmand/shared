using CesarBmx.Application.FakeResponses;
using CesarBmx.Application.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace CesarBmx.Api.ResponseExamples
{
    public class VersionResponseExample : IExamplesProvider<VersionResponse>
    {
        public VersionResponse GetExamples()
        {
            return VersionFakeResponse.GetFake_Production();
        }
    }
}