


namespace CesarBmx.Shared.Common.Extensions
{
    public static class DecimalExtension
    {
        /// <summary>
        /// It removes the ending zeros
        /// </summary>
        /// <param name="value">Value to normalize</param>
        /// <returns></returns>
        public static decimal Normalize(this decimal value)
        {
            var result = value / 1.000000000000000000000000000000000m;
            return result;
        }
    }
}
