
namespace DataAccess.Interface
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string userName);
        Task<User[]> GetAllUsersAsync();
    }
}
