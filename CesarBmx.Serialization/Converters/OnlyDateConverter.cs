using Newtonsoft.Json.Converters;

namespace CesarBmx.Serialization.Converters
{
    public class OnlyDateConverter: IsoDateTimeConverter
    {
        public OnlyDateConverter()
        {
            DateTimeFormat = "yyyy-MM-dd";
        }
    }
}