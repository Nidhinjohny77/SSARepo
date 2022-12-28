

namespace Business.Interface.Validators
{
    public interface IUserValidator
    {
        Task<List<ValidationModel>> ValidateAsync(string loggedInUser, UserModel user);
    }
}
