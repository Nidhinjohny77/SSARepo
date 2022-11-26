

namespace Business.Interface
{
    public interface IUserValidator
    {
        Task<List<ValidationResult>> ValidateAsync(string loggedInUser, UserModel user);
    }
}
