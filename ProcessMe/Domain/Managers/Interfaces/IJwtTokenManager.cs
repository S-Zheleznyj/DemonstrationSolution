using Microsoft.AspNetCore.Identity;
using ProcessMe.Models.DTOs.Incoming;
using ProcessMe.Models.DTOs.Outgoing;
using ProcessMe.Models.Entities;

namespace ProcessMe.Domain.Managers.Interfaces
{
    public interface IJwtTokenManager
    {
        Task<AuthResult> GenerateJwtTokenAsync(IdentityUser user, IList<string> roles);
        Task<RefreshToken> GetRefreshTokenByValueAsync(string refreshToken);
        TokenVerifyResult VerifyRefreshToken(RefreshToken storedToken, string jti, out string userId);
        TokenVerifyResult VerifyToken(string token, out string jti);
        Task UpdateRefreshTokenAsync(RefreshToken refreshToken);
    }
}
