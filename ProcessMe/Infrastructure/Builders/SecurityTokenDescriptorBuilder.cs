using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ProcessMe.Infrastructure.Configurations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ProcessMe.Infrastructure.Builders
{
    public static class SecurityTokenDescriptorBuilder
    {
        public static SecurityTokenDescriptor Build(IdentityUser user, TimeSpan expiryTimeFrame, byte[] key, IList<string> roles)
        {
            var now = DateTime.UtcNow;
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString())
            };
            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role));
            }
            var claimsIdentity = new ClaimsIdentity(claims);

            return new SecurityTokenDescriptor()
            {
                Subject = claimsIdentity,
                NotBefore = now,
                Expires = now.Add(expiryTimeFrame),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
        }
    }
}
