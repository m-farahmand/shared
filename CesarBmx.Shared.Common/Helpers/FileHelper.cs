using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CesarBmx.Shared.Common.Helpers
{
    public static class FileHelper
    {
        public static List<Type> GetTypes(Type @interface, Assembly assembly)
        {
            var types = from t in assembly.GetTypes()
                where t.GetInterfaces().Contains(@interface) 
                select t;

            return types.ToList();
        }
    }
}
