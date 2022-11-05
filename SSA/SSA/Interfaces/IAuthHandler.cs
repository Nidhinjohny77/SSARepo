namespace SSA.Interfaces
{
    public interface IAuthHandler
    {
        Task<string> AuthenticateAsync(UserCredentialModel credentials);
    }
}
