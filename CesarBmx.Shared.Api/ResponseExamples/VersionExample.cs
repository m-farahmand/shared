using CesarBmx.Shared.Application.FakeResponses;
using CesarBmx.Shared.Application.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace CesarBmx.Shared.Api.ResponseExamples
{
    public class VersionExample : IExamplesProvider<Version>
    {
        public Version GetExamples()
        {
            return FakeVersion.GetFake_Production();
        }
    }
}