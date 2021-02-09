


namespace CesarBmx.Shared.Common.Extensions
{
    public static class DecimalExtensions
    {
        public static decimal Normalize(this decimal value)
        {
            return value / 1.000000000000000000000000000000000m;
        }
    }
}
