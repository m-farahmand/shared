using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace CesarBmx.Api.ActionFilters
{
    public class HangfireNonAuthorization :  IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {

            return true;
        }
    }
}