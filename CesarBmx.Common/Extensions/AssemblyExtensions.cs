using System;
using System.IO;
using System.Reflection;

namespace CesarBmx.Common.Extensions
{
    public static class AssemblyExtensions
    {
        public static string VersionNumber(this Assembly assembly)
        {
            return assembly.GetName().Version.ToString();
        }
        public static DateTime Date(this Assembly assembly)
        {
            // Build date
            var location = assembly.Location;
            if (location == null) throw new NotImplementedException("Assembly.Location is null");
            var builDate = File.GetLastWriteTime(location);
            return builDate;
        }
    }
}