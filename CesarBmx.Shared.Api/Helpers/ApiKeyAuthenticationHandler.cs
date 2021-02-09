using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using CesarBmx.Shared.Application.Responses;
using CesarBmx.Shared.Application.Settings;
using ErrorMessage = CesarBmx.Shared.Application.Messages.ErrorMessage;

namespace CesarBmx.Shared.Api.Helpers
{
    public class ApiKeyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly AuthenticationSettings _authenticationSettings;

        public ApiKeyAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            AuthenticationSettings authenticationSettings)
            : base(options, logger, encoder, clock)
        {
            _authenticationSettings = authenticationSettings;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var partnerKey = Context.Request.Headers["Authorization"].ToString();
            if (partnerKey != _authenticationSettings.ApiKey)  return AuthenticateResult.NoResult();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, "partner"),
                new Claim(ClaimTypes.Name, "Partner")
            };
            var identity = new ClaimsIdentity(claims, "Custom");
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name );

             return AuthenticateResult.Success(ticket);
        }
        protected override async Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            Context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            Context.Response.ContentType = "application/json; charset=utf-8";
            var errorResponse = new Unauthorized(nameof(ErrorMessage.Unauthorized), ErrorMessage.Unauthorized);
            var response = JsonConvert.SerializeObject(errorResponse);
            await Context.Response.WriteAsync(response);
        }

        protected override async Task HandleForbiddenAsync(AuthenticationProperties properties)
        {
            Context.Response.StatusCode = StatusCodes.Status403Forbidden;
            Context.Response.ContentType = "application/json; charset=utf-8";
            var errorResponse = new Unauthorized(nameof(ErrorMessage.Forbidden), ErrorMessage.Forbidden);
            var response = JsonConvert.SerializeObject(errorResponse);
            await Context.Response.WriteAsync(response);
        }
    }
}
