using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using CesarBmx.Api.Helpers;
using CesarBmx.Api.Settings;
using CesarBmx.Application.Messages;
using CesarBmx.Application.Responses;

namespace CesarBmx.Api.Configuration
{
    public static class AuthenticationConfig
    {
        public static IServiceCollection UsePinnacleAuthentication(this IServiceCollection services,
            IConfiguration configuration)
        {
            // Grab AuthenticationSettings
            var authenticationSettings = new AuthenticationSettings();
            configuration.GetSection("AuthenticationSettings").Bind(authenticationSettings);

            // Configure JWT authentication
            var key = Encoding.ASCII.GetBytes(authenticationSettings.Secret);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = ClaimTypes.NameIdentifier,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                    x.Events = new JwtBearerEvents()
                    {
                        OnMessageReceived = context =>
                        {
                            // First, get the value from the cookie. If no cookie present, then use the authorization header
                            context.Token =
                                context.Request.Cookies["AccessToken"] ??
                                context.Request.Headers["Authorization"];
                            return Task.CompletedTask;
                        },
                        // Add body to 401/403
                        OnChallenge = context =>
                        {
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            context.Response.ContentType = "application/json; charset=utf-8";
                            var errorResponse = new UnauthorizedResponse(nameof(ErrorMessage.Unauthorized),
                                ErrorMessage.Unauthorized);
                            var result = JsonConvert.SerializeObject(errorResponse);
                            return context.Response.WriteAsync(result);
                        },
                        OnForbidden = context =>
                        {
                            context.Response.StatusCode = StatusCodes.Status403Forbidden;
                            context.Response.ContentType = "application/json; charset=utf-8";
                            var errorResponse = new UnauthorizedResponse(nameof(ErrorMessage.Forbidden),
                                ErrorMessage.Forbidden);
                            var result = JsonConvert.SerializeObject(errorResponse);
                            return context.Response.WriteAsync(result);
                        }
                    };
                });

            return services;
        }
        public static IServiceCollection UseFakeAuthentication(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAuthentication("FakeAuthentication")
                .AddScheme<AuthenticationSchemeOptions, FakeAuthenticationHandler>("FakeAuthentication", null);

            return services;
        }
    }
}