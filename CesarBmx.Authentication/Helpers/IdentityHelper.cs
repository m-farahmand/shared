using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using CesarBmx.Authentication.Attributes;

namespace CesarBmx.Authentication.Helpers
{
    public class IdentityHelper
    {
        public static void SetIdentityValues<T>(ref T obj, List<Claim> claims)
        {
            // Return if there is no request object 
            if (obj == null) return;
            // Grab all properties within the request
            var properties = obj.GetType().GetProperties();
            // Grab the property decorated with Identity attribute
            foreach (var property in properties)
            {
                var identityAttributes = property.GetCustomAttributes(typeof(IdentityAttribute), false);
                // ReSharper disable once UnusedVariable
                foreach (var identityAttribute in identityAttributes)
                {
                    //var claimName = ClaimTypes.Name; // ((Identity)identityAttribute).ClaimName;
                    var propertyName = property.Name; // Get the property name
                    // Return if there is not property to set
                    if (string.IsNullOrEmpty(propertyName)) return;
                    // Get the userId from the identity 
                    var userId = claims.FirstOrDefault(x => x.Type == ((IdentityAttribute)identityAttribute).ClaimName)?.Value;
                    // Set the value in the property
                    property.SetValue(obj, userId);
                }

            }
        }
    }
}