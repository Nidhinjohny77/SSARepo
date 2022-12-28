

namespace Business.Manager
{
    public class TenantManager : ITenantManager
    {
        private readonly IUnitOfWork uow;
        private readonly ITenantRepository tenantRepository;
        private readonly IMapper mapper;
        private readonly ITenantValidator validator;

        public TenantManager(IUnitOfWork uow,IMapper mapper,ITenantValidator validator)
        {
            this.uow = uow;
            this.tenantRepository = this.uow.TenantRepository;           
            this.mapper = mapper;
            this.validator = validator;
        }


        public async Task<Result<TenantPreferenceModel>> CreateTenantPreferencesAysnc(string loggedInUser, TenantPreferenceModel tenantPreference)
        {
            try
            {
                var validationResults = await this.validator.ValidateTenantPreferenceAsync(loggedInUser, tenantPreference);
                if (validationResults.Any())
                {
                    return await Task.FromResult<Result<TenantPreferenceModel>>(new Result<TenantPreferenceModel>(new BusinessException(validationResults)));
                }
                var existingPreference = await this.tenantRepository.GetTenantPreferenceAsync(tenantPreference.TenantUID);
                if (existingPreference != null)
                {
                    return await Task.FromResult<Result<TenantPreferenceModel>>(new Result<TenantPreferenceModel>(
                        new BusinessException(new ValidationModel("Tenant Preference already exists."))));
                }
                var newPreference=this.mapper.Map<TenantPreference>(tenantPreference);
                if(newPreference != null)
                {
                    newPreference.UID = Guid.NewGuid().ToString();
                    newPreference.CreatedBy = loggedInUser;
                    newPreference.CreatedDate=DateTime.Now;
                    newPreference.LastUpdatedBy = loggedInUser;
                    newPreference.LastUpdatedDate=DateTime.Now;
                    if (await this.tenantRepository.CreateTenantPreferenceAsync(newPreference))
                    {
                        if(await this.uow.SaveChangesAsync() > 0)
                        {
                            var savedEntity = await this.tenantRepository.GetTenantPreferenceAsync(newPreference.TenantUID);
                            var resultModel = this.mapper.Map<TenantPreferenceModel>(savedEntity);
                            if(resultModel != null)
                            {
                                return await Task.FromResult<Result<TenantPreferenceModel>>(new Result<TenantPreferenceModel>(resultModel));
                            }
                            else
                            {
                                return await Task.FromResult<Result<TenantPreferenceModel>>(new Result<TenantPreferenceModel>(
                                    new BusinessException(new ValidationModel("Unable to retrieve saved TenantPreference data from database."))));
                            }
                        }
                        else
                        {
                            return await Task.FromResult<Result<TenantPreferenceModel>>(new Result<TenantPreferenceModel>(
                                new BusinessException(new ValidationModel("Unable to persist given TenantPreference data to database."))));
                        }
                    }
                    else
                    {
                        return await Task.FromResult<Result<TenantPreferenceModel>>(new Result<TenantPreferenceModel>(
                            new BusinessException(new ValidationModel("Unable to save given TenantPreference data to database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<TenantPreferenceModel>>(new Result<TenantPreferenceModel>(
                        new BusinessException(new ValidationModel("Unable to map given TenantPreference model to database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<TenantPreferenceModel>>(new Result<TenantPreferenceModel>(ex));
            }
        }

        public async Task<Result<TenantModel>> CreateTenantProfileAysnc(string loggedInUser, TenantModel tenant)
        {
            try
            {
                var validationResults = await this.validator.ValidateTenantAsync(loggedInUser, tenant);
                if (validationResults.Any())
                {
                    return await Task.FromResult<Result<TenantModel>>(new Result<TenantModel>(new BusinessException(validationResults)));
                }
                var existingProfile = await this.tenantRepository.GetTenantAsync(tenant.UserUID);
                if (existingProfile != null)
                {
                    return await Task.FromResult<Result<TenantModel>>(new Result<TenantModel>(
                        new BusinessException(new ValidationModel("Tenant Profile already exists."))));
                }
                var newTenant = this.mapper.Map<Tenant>(tenant);
                if (newTenant != null)
                {
                    newTenant.UID = Guid.NewGuid().ToString();
                    newTenant.CreatedBy = loggedInUser;
                    newTenant.CreatedDate = DateTime.Now;
                    newTenant.LastUpdatedBy = loggedInUser;
                    newTenant.LastUpdatedDate = DateTime.Now;
                    if (await this.tenantRepository.CreateTenantAsync(newTenant))
                    {
                        if (await this.uow.SaveChangesAsync() > 0)
                        {
                            var savedEntity = await this.tenantRepository.GetTenantByUserUIDAsync(newTenant.UserUID);
                            var resultModel = this.mapper.Map<TenantModel>(savedEntity);
                            if (resultModel != null)
                            {
                                return await Task.FromResult<Result<TenantModel>>(new Result<TenantModel>(resultModel));
                            }
                            else
                            {
                                return await Task.FromResult<Result<TenantModel>>(new Result<TenantModel>(
                                    new BusinessException(new ValidationModel("Unable to retrieve saved Tenant data from database."))));
                            }
                        }
                        else
                        {
                            return await Task.FromResult<Result<TenantModel>>(new Result<TenantModel>(
                                new BusinessException(new ValidationModel("Unable to persist given Tenant data to database."))));
                        }
                    }
                    else
                    {
                        return await Task.FromResult<Result<TenantModel>>(new Result<TenantModel>(
                            new BusinessException(new ValidationModel("Unable to save given Tenant data to database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<TenantModel>>(new Result<TenantModel>(
                        new BusinessException(new ValidationModel("Unable to map given Tenant model to database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<TenantModel>>(new Result<TenantModel>(ex));
            }
        }

        public async Task<Result<bool>> DeleteTenantPreferencesAsync(string loggedInUser, string tenantPreferenceUID)
        {
            try
            {
                var existingPreference = await this.tenantRepository.GetTenantPreferenceByUIDAsync(tenantPreferenceUID);
                if (existingPreference == null)
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(
                        new BusinessException(new ValidationModel("Tenant preference does not exists."))));
                }
                await this.tenantRepository.DeleteTenantPreferenceAsync(existingPreference);
                if (await this.uow.SaveChangesAsync() > 0)
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(true));
                }
                else
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(
                        new BusinessException(new ValidationModel("Unable to delete the tenant preference from database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<bool>>(new Result<bool>(ex));
            }
        }

        public async Task<Result<bool>> DeleteTenantProfileAsync(string loggedInUser)
        {
            try
            {
                var existingProfile = await this.tenantRepository.GetTenantByUserUIDAsync(loggedInUser);
                if (existingProfile == null)
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(
                        new BusinessException(new ValidationModel("Tenant profile does not exists."))));
                }
                await this.tenantRepository.DeleteTenantAsync(existingProfile);
                if (await this.uow.SaveChangesAsync() > 0)
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(true));
                }
                else
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(
                        new BusinessException(new ValidationModel("Unable to delete the tenant profile from database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<bool>>(new Result<bool>(ex));
            }
        }

        public async Task<Result<TenantPreferenceModel>> GetTenantPreferencesAsync(string loggedInUser, string tenantUID)
        {
            try
            {
                var entity = await this.tenantRepository.GetTenantPreferenceAsync(tenantUID);
                if (entity == null)
                {
                    return await Task.FromResult<Result<TenantPreferenceModel>>(new Result<TenantPreferenceModel>(
                        new BusinessException(new ValidationModel("Tenant preference not available."))));
                }
                else
                {
                    var model = this.mapper.Map<TenantPreferenceModel>(entity);
                    return await Task.FromResult<Result<TenantPreferenceModel>>(new Result<TenantPreferenceModel>(model));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<TenantPreferenceModel>>(new Result<TenantPreferenceModel>(ex));
            }
        }

        public async Task<Result<TenantModel>> GetTenantProfileAsync(string loggedInUser)
        {
            try
            {
                var entity = await this.tenantRepository.GetTenantByUserUIDAsync(loggedInUser);
                if (entity == null)
                {
                    return await Task.FromResult<Result<TenantModel>>(new Result<TenantModel>(
                        new BusinessException(new ValidationModel("Tenant profile is not available."))));
                }
                else
                {
                    var model = this.mapper.Map<TenantModel>(entity);
                    return await Task.FromResult<Result<TenantModel>>(new Result<TenantModel>(model));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<TenantModel>>(new Result<TenantModel>(ex));
            }
        }

        public async Task<Result<TenantPreferenceModel>> UpdateTenantPreferencesAsync(string loggedInUser, TenantPreferenceModel tenantPreference)
        {
            try
            {
                var validationResults = await this.validator.ValidateTenantPreferenceAsync(loggedInUser, tenantPreference);
                if (validationResults.Any())
                {
                    return await Task.FromResult<Result<TenantPreferenceModel>>(new Result<TenantPreferenceModel>(new BusinessException(validationResults)));
                }
                var existingPreference = await this.tenantRepository.GetTenantPreferenceAsync(tenantPreference.TenantUID);
                if (existingPreference == null)
                {
                    return await Task.FromResult<Result<TenantPreferenceModel>>(new Result<TenantPreferenceModel>(
                        new BusinessException(new ValidationModel("Tenant Preference doesn't exists."))));
                }
                existingPreference = this.mapper.Map<TenantPreferenceModel, TenantPreference>(tenantPreference, existingPreference);
                existingPreference.LastUpdatedBy = loggedInUser;
                existingPreference.LastUpdatedDate = DateTime.Now;
                if (await this.tenantRepository.UpdateTenantPreferenceAsync(existingPreference))
                {
                    if (await this.uow.SaveChangesAsync() > 0)
                    {
                        var resultModel = this.mapper.Map<TenantPreferenceModel>(existingPreference);
                        if (resultModel != null)
                        {
                            return await Task.FromResult<Result<TenantPreferenceModel>>(new Result<TenantPreferenceModel>(resultModel));
                        }
                        else
                        {
                            return await Task.FromResult<Result<TenantPreferenceModel>>(new Result<TenantPreferenceModel>(
                                new BusinessException(new ValidationModel("Unable to map updated TenantPreference data from database."))));
                        }
                    }
                    else
                    {
                        return await Task.FromResult<Result<TenantPreferenceModel>>(new Result<TenantPreferenceModel>(
                            new BusinessException(new ValidationModel("Unable to persist TenantPreference data changes to database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<TenantPreferenceModel>>(new Result<TenantPreferenceModel>(
                        new BusinessException(new ValidationModel("Unable to update given TenantPreference data to database."))));
                }

            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<TenantPreferenceModel>>(new Result<TenantPreferenceModel>(ex));
            }
        }

        public async Task<Result<TenantModel>> UpdateTenantProfileAsync(string loggedInUser, TenantModel tenant)
        {
            try
            {
                var validationResults = await this.validator.ValidateTenantAsync(loggedInUser, tenant);
                if (validationResults.Any())
                {
                    return await Task.FromResult<Result<TenantModel>>(new Result<TenantModel>(new BusinessException(validationResults)));
                }
                var existingProfile = await this.tenantRepository.GetTenantAsync(tenant.UID);
                if (existingProfile == null)
                {
                    return await Task.FromResult<Result<TenantModel>>(new Result<TenantModel>(
                        new BusinessException(new ValidationModel("Tenant Profile doesn't exists."))));
                }
                existingProfile = this.mapper.Map<TenantModel, Tenant>(tenant, existingProfile);
                existingProfile.LastUpdatedBy = loggedInUser;
                existingProfile.LastUpdatedDate = DateTime.Now;
                if (await this.tenantRepository.UpdateTenantAsync(existingProfile))
                {
                    if (await this.uow.SaveChangesAsync() > 0)
                    {
                        var resultModel = this.mapper.Map<TenantModel>(existingProfile);
                        if (resultModel != null)
                        {
                            return await Task.FromResult<Result<TenantModel>>(new Result<TenantModel>(resultModel));
                        }
                        else
                        {
                            return await Task.FromResult<Result<TenantModel>>(new Result<TenantModel>(
                                new BusinessException(new ValidationModel("Unable to map updated Tenant Profile data from database."))));
                        }
                    }
                    else
                    {
                        return await Task.FromResult<Result<TenantModel>>(new Result<TenantModel>(
                            new BusinessException(new ValidationModel("Unable to persist Tenant Profile data changes to database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<TenantModel>>(new Result<TenantModel>(
                        new BusinessException(new ValidationModel("Unable to update given Tenant Profile data to database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<TenantModel>>(new Result<TenantModel>(ex));
            }
        }
    }
}
