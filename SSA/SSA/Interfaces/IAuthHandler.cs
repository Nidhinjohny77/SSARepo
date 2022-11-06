namespace SSA.Interfaces
{
    public interface IAuthHandler
    {
        Task<TokenModel> AuthenticateAsync(UserCredentialModel credentials);
        Task<TokenModel> RefreshTokenAsync(TokenModel expiredToken);
        Task<bool> RemoveTokenAsync(TokenModel token);
        Task<bool> IsTokenValid(string token);
    }
}
