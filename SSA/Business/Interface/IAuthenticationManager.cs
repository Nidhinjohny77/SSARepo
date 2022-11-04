

namespace Business.Interface
{
    public interface IAuthenticationManager
    {
        Task<UserModel> GetUser(string userName,string password);
    }
}
