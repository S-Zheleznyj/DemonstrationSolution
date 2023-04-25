using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProcessMe.Data;
using ProcessMe.Domain.Managers.Interfaces;
using ProcessMe.Infrastructure.Builders;
using ProcessMe.Infrastructure.Configurations;
using ProcessMe.Infrastructure.Extensions;
using ProcessMe.Infrastructure.Generators;
using ProcessMe.Models.DTOs.Incoming;
using ProcessMe.Models.DTOs.Outgoing;
using ProcessMe.Models.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProcessMe.Domain.Managers.Implementation
{
    public class JwtTokenManager : IJwtTokenManager
    {
        private readonly JwtConfig _jwtConfig;
        //Есть подозрения, что Repository паттерн не такая уж и нужная вещь.
        private readonly ProcessMeDbContext _context;

        public JwtTokenManager(IOptions<JwtConfig> jwtConfig, ProcessMeDbContext context)
        {
            _jwtConfig = jwtConfig.Value;
            _context = context;
        }

        public async Task<AuthResult> GenerateJwtTokenAsync(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_jwtConfig.Secret);

            TimeSpan expiryTimeFrame = TimeSpan.FromMinutes(_jwtConfig.Lifetime);
            var tokenDescriptor = SecurityTokenDescriptorBuilder.Build(user, expiryTimeFrame, key);

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            var refreshToken = RefreshTokenBuilder.Build(token.Id, user.Id);

            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();

            return new AuthResult()
            {
                IsSuccess = true,
                Token = jwtToken,
                RefreshToken = refreshToken.Token
            };
        }
        public TokenVerifyResult VerifyToken(string token, out string jti)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var tokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false, 
                ValidateAudience = false, 
                RequireExpirationTime = false, 
                ValidateLifetime = false
            };
            jti = null;
            try
            {
                var tokenInVerification = jwtTokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
                jti = tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);

                    if (!result)
                        return new TokenVerifyResult()
                        {
                            IsSuccess = false,
                            Errors = new()
                            {
                                "Invalid tokens"
                            }
                        };
                }

                var utcExpiryDate = long.Parse(tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

                var expiryDate = utcExpiryDate.UnixTimeStampToDateTime();
                if (expiryDate > DateTime.Now)
                {
                    return new TokenVerifyResult()
                    {
                        IsSuccess = false,
                        Errors = new()
                            {
                                "Invalid tokens"
                            }
                    };
                }

                return new TokenVerifyResult()
                {
                    IsSuccess = true
                };
            }
            catch
            {
                return new TokenVerifyResult()
                {
                    IsSuccess = false,
                    Errors = new()
                            {
                                "Server error"
                            }
                };
            }
        }
        public TokenVerifyResult VerifyRefreshToken(RefreshToken storedToken, string jti, out string userId)
        {
            userId = storedToken.UserId;
            if (storedToken == null || storedToken.IsUsed || storedToken.IsRevoked || storedToken.JwtId != jti)
                return new TokenVerifyResult()
                {
                    IsSuccess = false,
                    Errors = new()
                            {
                                "Invalid tokens"
                            }
                };

            if (storedToken.ExpiryDate < DateTime.UtcNow)
                return new TokenVerifyResult()
                {
                    IsSuccess = false,
                    Errors = new()
                            {
                                "Expired token"
                            }
                };
            return new TokenVerifyResult() { IsSuccess = true };
        }
        public async Task UpdateRefreshTokenAsync(RefreshToken refreshToken)
        {
            _context.RefreshTokens.Update(refreshToken);
            await _context.SaveChangesAsync();
        }
        public async Task<RefreshToken> GetRefreshTokenByValueAsync(string refreshToken)
        {
            return await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Token == refreshToken);
        }
    }
}
