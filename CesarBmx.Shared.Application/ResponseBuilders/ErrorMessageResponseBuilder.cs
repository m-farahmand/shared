using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CesarBmx.Shared.Application.Messages;
using CesarBmx.Shared.Application.Responses;


namespace CesarBmx.Shared.Application.ResponseBuilders
{
    public static class ErrorMessageResponseBuilder
    {
        public static Dictionary<string, ErrorMessageResponse> BuildErrorMessages()
        {
            var resources = new Dictionary<string, ErrorMessageResponse>();

            var query = from t in Assembly.GetExecutingAssembly().GetTypes()
                where t.IsClass && (t.Namespace != null && t.Namespace.Contains(".Application.Messages"))
                select t;
            var types = query.ToList();

            query = from t in typeof(ErrorMessage).Assembly.GetTypes()
                where t.IsClass && (t.Namespace != null && t.Namespace.Contains(".Application.Messages"))
                select t;

            types.AddRange(query.ToList());

            foreach (var type in types)
            {
                var constants = type.GetFields(BindingFlags.Public | BindingFlags.Static |
                                               BindingFlags.FlattenHierarchy)
                    .Where(fi => fi.IsLiteral && !fi.IsInitOnly).ToList();

                var errorMessage = new ErrorMessageResponse();

                foreach (var constant in constants)
                {
                    errorMessage.Add(constant.Name, constant.GetValue(null).ToString());
                }
                resources.Add(type.Name.Replace("Message", ""), errorMessage);
            }

            return resources.OrderBy(x=>x.Key).ToDictionary(pair => pair.Key, pair => pair.Value);
        }
    }
}
