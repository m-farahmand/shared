using CesarBmx.Shared.Application.FakeResponses;
using CesarBmx.Shared.Application.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace CesarBmx.Shared.Api.ResponseExamples
{
    public class VersionResponseExample : IExamplesProvider<VersionResponse>
    {
        public VersionResponse GetExamples()
        {
            return VersionFakeResponse.GetFake_Production();
        }
    }
}