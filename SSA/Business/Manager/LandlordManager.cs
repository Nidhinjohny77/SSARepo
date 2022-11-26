

namespace Business.Manager
{
    public class LandlordManager : ILandlordManager
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly ILandlordValidator validator;
        private readonly ILandlordRepository repository;

        public LandlordManager(IUnitOfWork uow,IMapper mapper, ILandlordValidator validator)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.validator = validator;
            this.repository = this.uow.LandlordRepository;
        }

        public async Task<Result<LandlordModel>> CreateLandlordProfileAysnc(string userUID, LandlordModel landlord)
        {
            try
            {
                
                landlord.UserUID = userUID;
                var validationResults=await this.validator.ValidateAsync(userUID, landlord);
                if (validationResults.Any())
                {
                    return await Task.FromResult<Result<LandlordModel>>(new Result<LandlordModel>(new BusinessException(validationResults)));
                }
                var existingProfile=await this.repository.GetLandlordAsync(landlord.UserUID);
                if (existingProfile != null)
                {
                    return await Task.FromResult<Result<LandlordModel>>(new Result<LandlordModel>(new BusinessException(new ValidationResult("The landlord profile already exists."))));
                }
                landlord.ProfileUID = Guid.NewGuid().ToString();
                var newLandLordEntity=this.mapper.Map<Landlord>(landlord);
                var flag=await this.repository.AddLandlordAsync(newLandLordEntity);
                if (flag)
                {
                    if(await this.uow.SaveChangesAsync() > 0)
                    {
                        return await Task.FromResult <Result<LandlordModel>>(new Result<LandlordModel>(landlord));
                    }
                    else
                    {
                        return await Task.FromResult<Result<LandlordModel>>(new Result<LandlordModel>(
                            new BusinessException(new ValidationResult("Unable to save the landlord profile to database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<LandlordModel>>(new Result<LandlordModel>(
                        new BusinessException(new ValidationResult("Unable to save the landlord profile to database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<LandlordModel>>(new Result<LandlordModel>(ex));
            }
        }

        public async Task<Result<bool>> DeleteLandlordProfileAsync(string userUID)
        {
            try
            {
                var existingProfile = await this.repository.GetLandlordAsync(userUID);
                if (existingProfile == null)
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(new BusinessException(new ValidationResult("The landlord profile doesn't exists."))));
                }
                var flag=await this.repository.DeleteLandlordAsync(existingProfile);
                if (flag)
                {
                    if (await this.uow.SaveChangesAsync() > 0)
                    {
                        return await Task.FromResult<Result<bool>>(new Result<bool>(true));
                    }
                    else
                    {
                        return await Task.FromResult<Result<bool>>(new Result<bool>(
                            new BusinessException(new ValidationResult("Unable to delete the landlord profile from database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(
                        new BusinessException(new ValidationResult("Unable to delete the landlord profile from database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<bool>>(new Result<bool>(ex));
            }
        }

        public async Task<Result<LandlordModel>> GetLandlordProfileAsync(string userUID)
        {
            try
            {
                var existingProfile = await this.repository.GetLandlordAsync(userUID);
                if (existingProfile == null)
                {
                    return await Task.FromResult<Result<LandlordModel>>(new Result<LandlordModel>(new BusinessException(new ValidationResult("The landlord profile doesn't exists."))));
                }
                var model=this.mapper.Map<LandlordModel>(existingProfile);
                return await Task.FromResult<Result<LandlordModel>>(new Result<LandlordModel>(model));
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<LandlordModel>>(new Result<LandlordModel>(ex));
            }
        }

        public async Task<Result<LandlordModel>> UpdateLandlordProfileAsync(string userUID, LandlordModel landlord)
        {
            try
            {
                landlord.UserUID = userUID;
                var validationResults = await this.validator.ValidateAsync(userUID, landlord);
                if (validationResults.Any())
                {
                    return await Task.FromResult<Result<LandlordModel>>(new Result<LandlordModel>(new BusinessException(validationResults)));
                }
                var existingProfile = await this.repository.GetLandlordAsync(landlord.UserUID);
                if (existingProfile == null)
                {
                    return await Task.FromResult<Result<LandlordModel>>(new Result<LandlordModel>(new BusinessException(new ValidationResult("The landlord profile doesn't exists."))));
                }
                var updatedLandLordEntity=this.mapper.Map<Landlord>(landlord);
                updatedLandLordEntity.UserUID= userUID;
                updatedLandLordEntity.ProfileUID = existingProfile.ProfileUID;
                var flag = await this.repository.UpdateLandlordAsync(updatedLandLordEntity);
                if (flag)
                {
                    if (await this.uow.SaveChangesAsync() > 0)
                    {
                        return await Task.FromResult<Result<LandlordModel>>(new Result<LandlordModel>(landlord));
                    }
                    else
                    {
                        return await Task.FromResult<Result<LandlordModel>>(new Result<LandlordModel>(
                            new BusinessException(new ValidationResult("Unable to update the landlord profile to database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<LandlordModel>>(new Result<LandlordModel>(
                        new BusinessException(new ValidationResult("Unable to update the landlord profile to database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<LandlordModel>>(new Result<LandlordModel>(ex));
            }
        }
    }
}
