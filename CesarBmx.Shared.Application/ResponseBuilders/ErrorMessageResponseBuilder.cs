using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using CesarBmx.Shared.Application.Responses;


namespace CesarBmx.Shared.Application.ResponseBuilders
{
    public static class ErrorMessageResponseBuilder
    {
        public static Dictionary<string, ErrorMessage> BuildErrorMessages()
        {
            var resources = new Dictionary<string, ErrorMessage>();

            var applicationAssemblies = new List<Assembly>();
            var  path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (path == null) return resources;

            foreach (var dll in Directory.GetFiles(path, "*Application.dll"))
                applicationAssemblies.Add(Assembly.LoadFile(dll));

            var types = new List<Type>();

         
            foreach (var applicationAssembly in applicationAssemblies)
            {
                var query = from t in applicationAssembly.GetTypes()
                    where t.IsClass && (t.Namespace != null && t.Namespace.Contains(".Application.Messages"))
                    select t;
                types.AddRange(query.ToList());
            }
            
            foreach (var type in types)
            {
                var constants = type.GetFields(BindingFlags.Public | BindingFlags.Static |
                                               BindingFlags.FlattenHierarchy)
                    .Where(fi => fi.IsLiteral && !fi.IsInitOnly).ToList();

                var errorMessage = new ErrorMessage();

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
