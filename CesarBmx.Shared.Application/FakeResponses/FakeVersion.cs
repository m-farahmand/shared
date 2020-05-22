using CesarBmx.Shared.Application.Responses;


namespace CesarBmx.Shared.Application.FakeResponses
{
    public static class FakeVersion
    {
        public static Version GetFake_Production()
        {
            return new Version
            {
                VersionNumber = "1.0.0.0",
                BuildDateTime = "2017/08/30 06:20",
                LastBuildOccurred = "40 seconds ago",
            };
        }
    }
}
