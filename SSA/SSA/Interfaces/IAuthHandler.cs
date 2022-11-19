using System.Security.Claims;

namespace SSA.Interfaces
{
    public interface IAuthHandler
    {
        Task<TokenModel> AuthenticateAsync(UserCredentialModel credentials);
        Task<TokenModel> RefreshTokenAsync(TokenModel expiredToken);
        Task<bool> RemoveTokenAsync(TokenModel token);
        bool IsTokenValid(string token,out ClaimsPrincipal claims);
    }
}
