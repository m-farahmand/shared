using System;
using System.Linq;

namespace CesarBmx.Shared.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool IsUrl(this string input)
        {
            Uri uriResult;
            return Uri.TryCreate(input, UriKind.Absolute, out uriResult)
                          && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
        public static string ToFirstLetterLower(this string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            var firstLetter = input.Substring(0,1);
            return firstLetter.ToLower() + input.Substring(1, input.Length - 1);
        }
        public static string ToReadable(this string input)
        {
            input = input.ToFirstLetterLower();
            var capitalLetters = string.Concat(input.Where(c => c >= 'A' && c <= 'Z'));
            foreach (var capitalLetter in capitalLetters)
            {
                var index = input.LastIndexOf(capitalLetter);
                var firstPart = input.Substring(0, index);
                var lowerLetter = " " + capitalLetter.ToString().ToLower();
                var secondPart = input.Substring(index + 1, input.Length - index - 1);
                input = firstPart + lowerLetter + secondPart;
            }
            return input;
        }
    }
}
