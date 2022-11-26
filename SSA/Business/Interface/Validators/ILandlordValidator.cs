
namespace Business.Interface.Validators
{
    public interface ILandlordValidator
    {
        Task<List<ValidationResult>> ValidateAsync(string loggedInUser, LandlordModel model);
    }
}
