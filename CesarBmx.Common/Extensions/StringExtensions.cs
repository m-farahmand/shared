using System;

namespace CesarBmx.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool IsUrl(this string input)
        {
            Uri uriResult;
            return Uri.TryCreate(input, UriKind.Absolute, out uriResult)
                          && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
