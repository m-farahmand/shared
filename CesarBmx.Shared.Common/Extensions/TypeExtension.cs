using System;

namespace CesarBmx.Shared.Common.Extensions
{
    public static class TypeExtension
    {
        public static string ToAlias(this Type type)
        {
            if (type.ToString() == "System.String") return "string";
            if (type.ToString() == "System.Int32") return "int";
            if (type.ToString() == "System.Int16") return "short";
            if (type.ToString() == "System.Boolean") return "bool";
            if (type.ToString() == "System.Object") return "object";
            if (type.ToString() == "System.Byte") return "byte";
            if (type.ToString() == "System.Char") return "string";
            if (type.ToString() == "System.Decimal") return "decimal";
            if (type.ToString() == "System.Double") return "double";
            if (type.ToString() == "System.SByte") return "sbyte";
            if (type.ToString() == "System.ushort") return "float";
            if (type.ToString() == "System.UInt32") return "uint";
            if (type.ToString() == "System.UInt64") return "ulong";
            if (type.ToString() == "System.Void") return "void";


            return type.ToString().Replace("System.","");
        }
    }
}
