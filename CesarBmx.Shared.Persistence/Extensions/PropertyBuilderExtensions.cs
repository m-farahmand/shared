using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CesarBmx.Shared.Persistence.Extensions
{
    public static class PropertyBuilderExtensions
    {
        public static PropertyBuilder HasStringToEnumConversion<TEnum>(this PropertyBuilder<TEnum> propertyBuilder) where TEnum : struct
        {
            return propertyBuilder.HasConversion(
                v => v.ToString(),
                v => (TEnum)Enum.Parse(typeof(TEnum), v));
        }
        public static PropertyBuilder HasStringToEnumConversion<TEnum>(this PropertyBuilder<TEnum?> propertyBuilder) where TEnum : struct
        {
            return propertyBuilder.HasConversion(
                v => v.ToString(),
                v => (TEnum)Enum.Parse(typeof(TEnum), v));
        }
    }
}
