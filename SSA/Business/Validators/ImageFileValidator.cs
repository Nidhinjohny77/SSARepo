

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

        public async Task<List<ValidationModel>> ValidateFileImageAsync(string loggedInUser, ImageModel model)
        {
            var validationResults = new List<ValidationModel>();

            if (loggedInUser == null)
            {
                validationResults.Add(new ValidationModel("Invalid LoggedIn user."));
            }
            if(model == null)
            {
                validationResults.Add(new ValidationModel("Image file is not present."));
            }
            else
            {
                if (string.IsNullOrEmpty(model.FileName))
                {
                    validationResults.Add(new ValidationModel("Image file name is a mandatory field."));
                }
                if (string.IsNullOrEmpty(model.FileType))
                {
                    validationResults.Add(new ValidationModel("Image file type is a mandatory field."));
                }
                if (model.Data==null)
                {
                    validationResults.Add(new ValidationModel("Image file data is null or empty."));
                }
                else
                {
                    if (!FileConstant.AcceptedImageFileTypes.Contains(model.FileType.ToUpper()))
                    {
                        validationResults.Add(new ValidationModel("Invalid image file type."));
                    }
                }
            }
            return await Task.FromResult<List<ValidationModel>>(validationResults);
        }
    }
}
