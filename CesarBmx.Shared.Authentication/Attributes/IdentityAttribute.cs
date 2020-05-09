
using System;
using System.Security.Claims;

namespace CesarBmx.Shared.Authentication.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IdentityAttribute : Attribute
    {
        public readonly string ClaimName = ClaimTypes.NameIdentifier;

        public IdentityAttribute(string claimName)
        {
            ClaimName = claimName;
        }

        public IdentityAttribute()
        {
        }
    }
}