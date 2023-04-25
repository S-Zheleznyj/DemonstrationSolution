using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ProcessMe.Infrastructure.Configurations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ProcessMe.Infrastructure.Builders
{
    public static class SecurityTokenDescriptorBuilder
    {
        public static SecurityTokenDescriptor Build(IdentityUser user, TimeSpan expiryTimeFrame, byte[] key)
        {
            var now = DateTime.UtcNow;
            return new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString())
                }),
                NotBefore = now,
                Expires = now.Add(expiryTimeFrame),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
        }
    }
}
