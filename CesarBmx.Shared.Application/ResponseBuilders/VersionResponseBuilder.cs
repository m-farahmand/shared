using System.Reflection;
using CesarBmx.Shared.Application.Responses;
using CesarBmx.Shared.Common.Extensions;

namespace CesarBmx.Shared.Application.ResponseBuilders
{
    public static class VersionResponseBuilder
    {
        public static Version Build(this Version versionResponse, Assembly assembly)
        {
            var assemblyDate = assembly.Date();
            versionResponse.BuildDateTime = assemblyDate.ToString("yyyy/MM/dd HH:mm");
            versionResponse.LastBuildOccurred = assemblyDate.DaysHoursMinutesAndSecondsSinceDate();
            versionResponse.VersionNumber = assembly.VersionNumber();

            return versionResponse;
        }
    }
}
