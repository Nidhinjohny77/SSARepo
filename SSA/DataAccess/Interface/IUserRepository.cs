
namespace DataAccess.Interface
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string userName);
        Task<User> GetUserByUIDAsync(string userUID);
        Task<User[]> GetAllUsersAsync();
        Task<User> CreateUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(User user);
    }
}
