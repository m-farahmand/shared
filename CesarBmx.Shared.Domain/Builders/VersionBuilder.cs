using System.Reflection;
using CesarBmx.Shared.Common.Extensions;
using CesarBmx.Shared.Domain.Entities;

namespace CesarBmx.Shared.Domain.Builders
{
    public static class VersionBuilder
    {
        public static Version BuildVersion(Assembly assembly, string environment)
        {
            return new Version(
                 // VersionNumber
                 assembly.VersionNumber(),
                 // LastBuildOccurred
                 assembly.Date(),
                environment
             );
        }
    }
}
