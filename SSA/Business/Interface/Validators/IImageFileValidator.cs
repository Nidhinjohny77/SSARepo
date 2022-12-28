
namespace Business.Interface.Validators
{
    public interface IImageFileValidator
    {
        Task<List<ValidationModel>> ValidateFileImageAsync(string loggedInUser, ImageModel model);
    }
}
