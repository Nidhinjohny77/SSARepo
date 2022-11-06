

namespace Business.Interface
{
    public interface IAuthenticationManager
    {
        Task<UserModel> GetUserAsync(string userName,string password);
    }
}
