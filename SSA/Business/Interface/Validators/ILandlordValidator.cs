
namespace Business.Interface.Validators
{
    public interface ILandlordValidator
    {
        Task<List<ValidationModel>> ValidateAsync(string loggedInUser, LandlordModel model);
    }
}
