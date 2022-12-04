

namespace Business.Manager
{
    public class PropertyManager : IPropertyManager
    {
        private readonly IUnitOfWork uow;
        private readonly IPropertyRepository repository;
        private readonly IMapper mapper;
        private readonly IPropertyValidator validator;

        public PropertyManager(IUnitOfWork uow,IMapper mapper,IPropertyValidator validator)
        {
            this.uow = uow;
            this.repository = this.uow.PropertyRepository;
            this.mapper = mapper;
            this.validator = validator;
        }
        public async Task<Result<PropertyModel>> CreatePropertyAsync(string userUID, PropertyModel property)
        {
            try
            {
                var validationResults = await this.validator.ValidatePropertyAsync(userUID, property);
                if (validationResults.Any())
                {
                    return await Task.FromResult<Result<PropertyModel>>(new Result<PropertyModel>(new BusinessException(validationResults)));
                }
                
                var newPropertyEntity = this.mapper.Map<Property>(property);
                newPropertyEntity.UID = Guid.NewGuid().ToString();
                newPropertyEntity.CreatedBy= userUID;
                newPropertyEntity.CreatedDate = DateTime.Now;
                newPropertyEntity.LastUpdatedBy = userUID;
                newPropertyEntity.LastUpdatedDate = DateTime.Now;
                var flag = await this.repository.AddPropertyAsync(newPropertyEntity);
                if (flag)
                {
                    if (await this.uow.SaveChangesAsync() > 0)
                    {
                        var newPropertyModel=this.mapper.Map<PropertyModel>(newPropertyEntity);
                        return await Task.FromResult<Result<PropertyModel>>(new Result<PropertyModel>(newPropertyModel));
                    }
                    else
                    {
                        return await Task.FromResult<Result<PropertyModel>>(new Result<PropertyModel>(
                            new BusinessException(new ValidationResult("Unable to save the property profile to database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<PropertyModel>>(new Result<PropertyModel>(
                        new BusinessException(new ValidationResult("Unable to save the property profile to database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<PropertyModel>>(new Result<PropertyModel>(ex));
            }
        }

        public async Task<Result<PropertyListingModel>> CreatePropertyListingAsync(string userUID, PropertyListingModel propertyListing)
        {
            try
            {
                var validationResults = await this.validator.ValidatePropertyListingAsync(userUID, propertyListing);
                if (validationResults.Any())
                {
                    return await Task.FromResult<Result<PropertyListingModel>>(new Result<PropertyListingModel>(new BusinessException(validationResults)));
                }
                var newPropertyListingEntity = this.mapper.Map<PropertyListing>(propertyListing);
                newPropertyListingEntity.UID= Guid.NewGuid().ToString();
                newPropertyListingEntity.CreatedBy = userUID;
                newPropertyListingEntity.CreatedDate= DateTime.Now;
                newPropertyListingEntity.LastUpdatedBy= userUID;
                newPropertyListingEntity.LastUpdatedDate= DateTime.Now;
                var flag = await this.repository.AddPropertyListingAsync(newPropertyListingEntity);
                if (flag)
                {
                    if (await this.uow.SaveChangesAsync() > 0)
                    {
                        var newPropertyListingModel=this.mapper.Map<PropertyListingModel>(newPropertyListingEntity);
                        return await Task.FromResult<Result<PropertyListingModel>>(new Result<PropertyListingModel>(newPropertyListingModel));
                    }
                    else
                    {
                        return await Task.FromResult<Result<PropertyListingModel>>(new Result<PropertyListingModel>(
                            new BusinessException(new ValidationResult("Unable to save the property listing profile to database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<PropertyListingModel>>(new Result<PropertyListingModel>(
                        new BusinessException(new ValidationResult("Unable to save the property listing profile to database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<PropertyListingModel>>(new Result<PropertyListingModel>(ex));
            }
        }

        public async Task<Result<PropertyViewingModel>> CreatePropertyViewing(string userUID, PropertyViewingModel propertyViewingModel)
        {
            try
            {
                var validationResults = await this.validator.ValidatePropertyViewingAsync(userUID, propertyViewingModel);
                if (validationResults.Any())
                {
                    return await Task.FromResult<Result<PropertyViewingModel>>(new Result<PropertyViewingModel>(new BusinessException(validationResults)));
                }
                var newPropertyViewingEntity = this.mapper.Map<PropertyViewing>(propertyViewingModel);
                newPropertyViewingEntity.UID = Guid.NewGuid().ToString();
                newPropertyViewingEntity.CreatedBy = userUID;
                newPropertyViewingEntity.CreatedDate = DateTime.Now;
                newPropertyViewingEntity.LastUpdatedBy = userUID;
                newPropertyViewingEntity.LastUpdatedDate = DateTime.Now;
                var flag = await this.repository.AddPropertyViewingAsync(newPropertyViewingEntity);
                if (flag)
                {
                    if (await this.uow.SaveChangesAsync() > 0)
                    {
                        var newPropertyViewingModel = this.mapper.Map<PropertyViewingModel>(newPropertyViewingEntity);
                        return await Task.FromResult<Result<PropertyViewingModel>>(new Result<PropertyViewingModel>(newPropertyViewingModel));
                    }
                    else
                    {
                        return await Task.FromResult<Result<PropertyViewingModel>>(new Result<PropertyViewingModel>(
                            new BusinessException(new ValidationResult("Unable to save the property viewing profile to database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<PropertyViewingModel>>(new Result<PropertyViewingModel>(
                        new BusinessException(new ValidationResult("Unable to save the property viewing profile to database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<PropertyViewingModel>>(new Result<PropertyViewingModel>(ex));
            }
        }

        public async Task<Result<bool>> DeleteAllPropertyImagesAsync(string userUID, string propertyUID)
        {
            try
            {
                var existingImages = this.repository.GetAllPropertyImages().Where(x=>x.IsActive && x.PropertyUID==propertyUID).ToList<PropertyImage>();
                if (!existingImages.Any())
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(new BusinessException(new ValidationResult("The given property image doesn't have any pictures uploaded."))));
                }
                bool flag = false;
                foreach (var item in existingImages)
                {
                    flag = await this.repository.DeletePropertyImageAsync(item) && flag;
                }
                
                if (flag)
                {
                    if (await this.uow.SaveChangesAsync() > 0)
                    {
                        return await Task.FromResult<Result<bool>>(new Result<bool>(true));
                    }
                    else
                    {
                        return await Task.FromResult<Result<bool>>(new Result<bool>(
                            new BusinessException(new ValidationResult("Unable to delete the property image from database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(
                        new BusinessException(new ValidationResult("Unable to delete the property image from database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<bool>>(new Result<bool>(ex));
            }
        }

        public async Task<Result<bool>> DeletePropertyAsync(string userUID, string propertyUID)
        {
            try
            {
                var existingProperty = this.repository.GetAllProperties().Where(x => x.IsActive && x.UID == propertyUID).FirstOrDefault<Property>();
                if (existingProperty==null)
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(new BusinessException(new ValidationResult("The given property profile doesn't exists."))));
                }
                bool flag = await this.repository.DeletePropertyAsync(existingProperty);

                if (flag)
                {
                    if (await this.uow.SaveChangesAsync() > 0)
                    {
                        return await Task.FromResult<Result<bool>>(new Result<bool>(true));
                    }
                    else
                    {
                        return await Task.FromResult<Result<bool>>(new Result<bool>(
                            new BusinessException(new ValidationResult("Unable to delete the property profile from database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(
                        new BusinessException(new ValidationResult("Unable to delete the property profile from database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<bool>>(new Result<bool>(ex));
            }
        }

        public async Task<Result<bool>> DeletePropertyImageAsync(string userUID, string propertyImageUID)
        {
            try
            {
                var existingPropertyImage = this.repository.GetAllPropertyImages().Where(x => x.IsActive && x.UID == propertyImageUID).FirstOrDefault<PropertyImage>();
                if (existingPropertyImage == null)
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(new BusinessException(new ValidationResult("The given property image doesn't have any pictures uploaded."))));
                }
                bool flag = await this.repository.DeletePropertyImageAsync(existingPropertyImage);

                if (flag)
                {
                    if (await this.uow.SaveChangesAsync() > 0)
                    {
                        return await Task.FromResult<Result<bool>>(new Result<bool>(true));
                    }
                    else
                    {
                        return await Task.FromResult<Result<bool>>(new Result<bool>(
                            new BusinessException(new ValidationResult("Unable to delete the property image from database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(
                        new BusinessException(new ValidationResult("Unable to delete the property image from database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<bool>>(new Result<bool>(ex));
            }
        }

        public async Task<Result<bool>> DeletePropertyListingAsync(string userUID, string propertyListingUID)
        {
            try
            {
                var existingPropertyListing = this.repository.GetAllPropertyListings().Where(x => x.IsActive && x.UID == propertyListingUID).FirstOrDefault<PropertyListing>();
                if (existingPropertyListing == null)
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(new BusinessException(new ValidationResult("The given property listing doesn't exist."))));
                }
                bool flag = await this.repository.DeletePropertyListingAsync(existingPropertyListing);

                if (flag)
                {
                    if (await this.uow.SaveChangesAsync() > 0)
                    {
                        return await Task.FromResult<Result<bool>>(new Result<bool>(true));
                    }
                    else
                    {
                        return await Task.FromResult<Result<bool>>(new Result<bool>(
                            new BusinessException(new ValidationResult("Unable to delete the property listing from database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(
                        new BusinessException(new ValidationResult("Unable to delete the property listing from database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<bool>>(new Result<bool>(ex));
            }
        }

        public async Task<Result<bool>> DeletePropertyViewing(string userUID, string propertyViewingUID)
        {
            try
            {
                var existingPropertyViewing = this.repository.GetAllPropertyViewings().Where(x => x.IsActive && x.UID == propertyViewingUID).FirstOrDefault<PropertyViewing>();
                if (existingPropertyViewing == null)
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(new BusinessException(new ValidationResult("The given property viewing doesn't exist."))));
                }
                bool flag = await this.repository.DeletePropertyViewingAsync(existingPropertyViewing);

                if (flag)
                {
                    if (await this.uow.SaveChangesAsync() > 0)
                    {
                        return await Task.FromResult<Result<bool>>(new Result<bool>(true));
                    }
                    else
                    {
                        return await Task.FromResult<Result<bool>>(new Result<bool>(
                            new BusinessException(new ValidationResult("Unable to delete the property viewing from database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(
                        new BusinessException(new ValidationResult("Unable to delete the property viewing from database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<bool>>(new Result<bool>(ex));
            }
        }

        public async Task<Result<PropertyImageModel[]>> GetAllPropertyImagesAsync(string userUID, string propertyUID)
        {
            try
            {
                var existingPropertyImages = this.repository.GetAllPropertyImages().Where(x => x.PropertyUID == propertyUID).ToList<PropertyImage>();
                if (existingPropertyImages == null)
                {
                    existingPropertyImages = new List<PropertyImage>();
                }
                var model = this.mapper.Map<PropertyImageModel[]>(existingPropertyImages.ToArray());
                return await Task.FromResult<Result<PropertyImageModel[]>>(new Result<PropertyImageModel[]>(model));
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<PropertyImageModel[]>>(new Result<PropertyImageModel[]>(ex));
            }
        }

        public async Task<Result<List<PropertyListingModel>>> GetAllPropertyListingsAsync(string userUID, string landlordProfileUID)
        {
            try
            {
                var properties=this.repository.GetAllProperties().Where(x=>x.LandlordProfileUID== landlordProfileUID).ToList<Property>();
                var propertyListings=new List<PropertyListing>();
                foreach (var property in properties)
                {
                    var listings=property.Listings.FindAll(x=>x.IsActive);
                    if (listings!=null && listings.Any())
                    {
                        propertyListings.AddRange(listings);
                    }
                }
                var model = this.mapper.Map<List<PropertyListingModel>>(propertyListings);
                return await Task.FromResult<Result<List<PropertyListingModel>>>(new Result<List<PropertyListingModel>>(model));
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<List<PropertyListingModel>>>(new Result<List<PropertyListingModel>>(ex));
            }
        }

        public async Task<Result<List<PropertyListingModel>>> GetAllPropertyListingsByFilterAsync(string userUID, PropertyListingFilterModel filter)
        {
            try
            {
                var propertyListingsQuery = this.repository.GetAllPropertyListings();
                if (filter != null)
                {
                    if (!string.IsNullOrEmpty(filter.Location))
                    {
                        propertyListingsQuery = propertyListingsQuery.Where(x => x.Property.Address.Contains(filter.Location));
                    }
                    if (filter.StartRent != null)
                    {
                        propertyListingsQuery = propertyListingsQuery.Where(x => x.ListingAmount>=filter.StartRent);
                    }
                    if (filter.EndRent != null)
                    {
                        propertyListingsQuery = propertyListingsQuery.Where(x => x.ListingAmount <= filter.EndRent);
                    }
                }
                var propertyListings=propertyListingsQuery.ToList();
                var model = this.mapper.Map<List<PropertyListingModel>>(propertyListings);
                return await Task.FromResult<Result<List<PropertyListingModel>>>(new Result<List<PropertyListingModel>>(model));
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<List<PropertyListingModel>>>(new Result<List<PropertyListingModel>>(ex));
            }
        }

        public Task<Result<List<PropertyViewingModel>>> GetAllPropertyViewingsByLandlordAsync(string userUID, string landlordUID)
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<PropertyViewingModel>>> GetAllPropertyViewingsByStudentAsync(string userUID, string studentUID)
        {
            throw new NotImplementedException();
        }

        public Task<Result<PropertyModel>> GetPropertyByLandlordAsync(string userUID, string landlordProfileUID)
        {
            throw new NotImplementedException();
        }

        public Task<Result<PropertyModel>> GetPropertyByUIDAsync(string userUID, string propertyUID)
        {
            throw new NotImplementedException();
        }

        public Task<Result<PropertyListingModel>> GetPropertyListingByUIDAsync(string userUID, string propertyListingUID)
        {
            throw new NotImplementedException();
        }

        public Task<Result<PropertyModel>> UpdatePropertyAsync(string userUID, PropertyModel property)
        {
            throw new NotImplementedException();
        }

        public Task<Result<PropertyListingModel>> UpdatePropertyListing(string userUID, PropertyListingModel propertyListing)
        {
            throw new NotImplementedException();
        }

        public Task<Result<PropertyViewingModel>> UpdatePropertyViewingAsync(string userUID, PropertyViewingModel propertyViewingModel)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> UploadPropertyImageAsync(string userUID, PropertyImageModel model)
        {
            throw new NotImplementedException();
        }
    }
}
