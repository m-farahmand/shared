using System.Reflection;
using CesarBmx.Common.Extensions;
using CesarBmx.Domain.Entities;

namespace CesarBmx.Domain.Builders
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
