using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CesarBmx.Shared.Api.Helpers
{
    public class FakeAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public FakeAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {}

        protected override  Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var user = Context.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(user)) user = "testuser";

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user),
                new Claim(ClaimTypes.Name, "Test user")
            };
            var identity = new ClaimsIdentity(claims, "Test");
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, "Test");

            var result = AuthenticateResult.Success(ticket);

            return Task.FromResult(result);
        }
    }
}
