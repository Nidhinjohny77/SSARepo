

namespace Business.Interface
{
    public interface IAuthenticationManager
    {
        Task<User> GetUserAsync(string userName,string password);
    }
}
