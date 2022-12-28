

namespace Business.Manager
{
    public class ImageFileManager:IImageFileManager
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IImageFileValidator validator;
        private readonly IImageFileRepository fileRepo;
        private readonly IUserRepository userRepo;

        public ImageFileManager(IUnitOfWork uow, IMapper mapper, IImageFileValidator validator)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.validator = validator;
            this.fileRepo = this.uow.ImageFileRepository;
            this.userRepo = this.uow.UserRepository;
        }

        public async Task<Result<bool>> DeleteImageAsync(string userUID,ImageModel imageModel)
        {
            try
            {
                var user=await this.userRepo.GetUserByUIDAsync(userUID);
                if (IsAuthorized(user))
                {
                    var existingEntity = await this.fileRepo.GetImageFileAsync(imageModel.UID);
                    if (existingEntity != null)
                    {
                        var flag = await this.fileRepo.DeleteImageFileAsync(existingEntity);
                        return await Task.FromResult<Result<bool>>(new Result<bool>(await this.uow.SaveChangesAsync() > 0));
                    }
                    else
                    {
                        return await Task.FromResult<Result<bool>>(new Result<bool>(new BusinessException(new ValidationModel("The given image doesn't exists."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(new BusinessException(new ValidationModel("The user doesn't have permission to delete the file."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<bool>>(new Result<bool>(ex));
            }
        }

        public async Task<Result<ImageModel>> UploadImageAsync(string userUID,ImageModel imageModel)
        {
            try
            {
                var user = await this.userRepo.GetUserByUIDAsync(userUID);
                if (IsAuthorized(user))
                {
                    var existingEntity = await this.fileRepo.GetImageFileAsync(imageModel.UID);
                    if (existingEntity != null)
                    {
                        return await Task.FromResult<Result<ImageModel>>(new Result<ImageModel>(new BusinessException(new ValidationModel("The given image exists."))));
                    }
                    else
                    {
                        var validationResults = await this.validator.ValidateFileImageAsync(userUID, imageModel);
                        if (validationResults.Any())
                        {
                            return await Task.FromResult<Result<ImageModel>>(new Result<ImageModel>(new BusinessException(validationResults)));
                        }
                        imageModel.UID=Guid.NewGuid().ToString();
                        var newEntity=this.mapper.Map<ImageFile>(imageModel);
                        var flag=await this.fileRepo.AddImageFileAsync(newEntity);
                        if (flag)
                        {
                            imageModel.Data = null;
                            return await Task.FromResult<Result<ImageModel>>(new Result<ImageModel>(imageModel));
                        }
                        else
                        {
                            return await Task.FromResult<Result<ImageModel>>(new Result<ImageModel>(new BusinessException(new ValidationModel("Unable to uplaod the file to database."))));
                        }
                    }
                }
                else
                {
                    return await Task.FromResult<Result<ImageModel>>(new Result<ImageModel>(new BusinessException(new ValidationModel("The user doesn't have permission to upload the file."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<ImageModel>>(new Result<ImageModel>(ex));
            }
        }

        private bool IsAuthorized(User user)
        {
            if (user == null)
            {
                return false;
            }
            else
            {
                return user.Role.Name == RoleConstant.Admin || user.Role.Name == RoleConstant.Consultant || user.Role.Name == RoleConstant.Landlord;
;            }
        }
    }
}
