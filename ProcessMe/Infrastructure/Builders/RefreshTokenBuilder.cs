using ProcessMe.Infrastructure.Generators;
using ProcessMe.Models.Entities;

namespace ProcessMe.Infrastructure.Builders
{
    public static class RefreshTokenBuilder
    {
        public static RefreshToken Build(string jwtId, string userId)
        {
            return new RefreshToken()
            {
                JwtId = jwtId,
                Token = RandomStringGenerator.Generate(23), //Generate a refresh token
                AddedDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddMonths(6),
                UserId = userId
            };
        }
    }
}
