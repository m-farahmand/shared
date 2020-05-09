using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;
using CesarBmx.Application.Exceptions;
using CesarBmx.Application.Messages;
using CesarBmx.Authentication.Helpers;

namespace CesarBmx.Api.ActionFilters
{
    public class IdentityFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Do nothing if there is no 'request' parameter
            if (!filterContext.ActionArguments.ContainsKey("request")) return;
            // Grab the request object
            var request = filterContext.ActionArguments["request"];
            // Grab the identity
            var identity = filterContext.HttpContext.User;
            // Request must be authenticated 
            if (identity == null) throw new UnauthorizedException(ErrorMessage.Unauthorized);
            // Set the identity values
            IdentityHelper.SetIdentityValues(ref request, identity.Claims.ToList());
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}