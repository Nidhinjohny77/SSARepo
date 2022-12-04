

namespace Business.Validators
{
    public class ImageFileValidator : IImageFileValidator
    {
        private readonly IUnitOfWork uow;
        private readonly IImageFileRepository fileRepo;

        public ImageFileValidator(IUnitOfWork uow)
        {
            this.uow = uow;
            this.fileRepo = this.uow.ImageFileRepository;
        }

        public async Task<List<ValidationResult>> ValidateFileImageAsync(string loggedInUser, ImageModel model)
        {
            var validationResults = new List<ValidationResult>();

            if (loggedInUser == null)
            {
                validationResults.Add(new ValidationResult("Invalid LoggedIn user."));
            }
            if(model == null)
            {
                validationResults.Add(new ValidationResult("Image file is not present."));
            }
            else
            {
                if (string.IsNullOrEmpty(model.FileName))
                {
                    validationResults.Add(new ValidationResult("Image file name is a mandatory field."));
                }
                if (string.IsNullOrEmpty(model.FileType))
                {
                    validationResults.Add(new ValidationResult("Image file type is a mandatory field."));
                }
                if (model.Data==null)
                {
                    validationResults.Add(new ValidationResult("Image file data is null or empty."));
                }
                else
                {
                    if (!FileConstant.AcceptedImageFileTypes.Contains(model.FileType.ToUpper()))
                    {
                        validationResults.Add(new ValidationResult("Invalid image file type."));
                    }
                }
            }
            return await Task.FromResult<List<ValidationResult>>(validationResults);
        }
    }
}
