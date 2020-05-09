using Newtonsoft.Json.Converters;

namespace CesarBmx.Shared.Serialization.Converters
{
    public class OnlyDateConverter: IsoDateTimeConverter
    {
        public OnlyDateConverter()
        {
            DateTimeFormat = "yyyy-MM-dd";
        }
    }
}