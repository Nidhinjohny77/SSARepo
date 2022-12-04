
namespace Business.Interface.Validators
{
    public interface IImageFileValidator
    {
        Task<List<ValidationResult>> ValidateFileImageAsync(string loggedInUser, ImageModel model);
    }
}
