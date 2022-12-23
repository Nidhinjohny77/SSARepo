
namespace Business.Interface
{
    public interface IUserManager
    {
        Task<Result<UserModel>> CreateUserAsync(UserModel user);
        Task<Result<UserModel>> UpdateUserAsync(string loggedInUser,UserModel user);
        Task<Result<bool>> DeleteUserAsync(string loggedInUser, UserModel user);
        Task<Result<UserModel>> GetUserAsync(string userUID);
        Task<Result<UserModel[]>> GetAllUsersAsync();
    }
}
