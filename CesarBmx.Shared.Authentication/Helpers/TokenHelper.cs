using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace CesarBmx.Shared.Authentication.Helpers
{
    public static class TokenHelper
    {
        public static string BuildJwtAccessToken(string user, string fullName, string secret, int? expirationTimeInMinutes = null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user),
                    new Claim(ClaimTypes.Name, fullName)
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            // Add expiration when it is provided nd it is greater than zero
            if (expirationTimeInMinutes != null && expirationTimeInMinutes > 0)
                tokenDescriptor.Expires = DateTime.UtcNow.AddMinutes(expirationTimeInMinutes.Value);

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}