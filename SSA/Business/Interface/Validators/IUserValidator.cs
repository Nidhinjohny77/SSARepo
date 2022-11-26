

namespace Business.Interface.Validators
{
    public interface IUserValidator
    {
        Task<List<ValidationResult>> ValidateAsync(string loggedInUser, UserModel user);
    }
}
