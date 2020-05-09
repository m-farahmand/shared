using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace CesarBmx.Shared.Api.Configuration
{
    public static class SerializationConfig
    {
        public static IMvcBuilder ConfigurePinnacleSerialization(this IMvcBuilder mvcBuilder)
        {
            mvcBuilder.AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
            });

            return mvcBuilder;
        }
    }
}
