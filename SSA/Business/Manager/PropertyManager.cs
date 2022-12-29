

namespace Business.Manager
{
    public class PropertyManager : IPropertyManager
    {
        private readonly IUnitOfWork uow;
        private readonly IPropertyRepository repository;
        private readonly IMapper mapper;
        private readonly IPropertyValidator validator;
        private readonly IImageFileValidator imageValidator;

        public PropertyManager(IUnitOfWork uow,IMapper mapper,IPropertyValidator validator,IImageFileValidator imageValidator)
        {
            this.uow = uow;
            this.repository = this.uow.PropertyRepository;
            this.mapper = mapper;
            this.validator = validator;
            this.imageValidator = imageValidator;
        }
        public async Task<Result<PropertyModel>> CreatePropertyAsync(string loggedInUser, PropertyModel property)
        {
            try
            {
                var validationResults = await this.validator.ValidatePropertyAsync(loggedInUser, property);
                if (validationResults.Any())
                {
                    return await Task.FromResult<Result<PropertyModel>>(new Result<PropertyModel>(new BusinessException(validationResults)));
                }
                
                var newPropertyEntity = this.mapper.Map<Property>(property);
                newPropertyEntity.UID = Guid.NewGuid().ToString();
                newPropertyEntity.CreatedBy= loggedInUser;
                newPropertyEntity.CreatedDate = DateTime.Now;
                newPropertyEntity.LastUpdatedBy = loggedInUser;
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
                            new BusinessException(new ValidationModel("Unable to save the property profile to database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<PropertyModel>>(new Result<PropertyModel>(
                        new BusinessException(new ValidationModel("Unable to save the property profile to database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<PropertyModel>>(new Result<PropertyModel>(ex));
            }
        }

        public async Task<Result<PropertyAttributeModel>> CreatePropertyAttributeAsync(string loggedInUser, PropertyAttributeModel propertyAttribute)
        {
            try
            {
                var validationResults = await this.validator.ValidatePropertyAttributeAsync(loggedInUser, propertyAttribute);
                if (validationResults.Any())
                {
                    return await Task.FromResult<Result<PropertyAttributeModel>>(new Result<PropertyAttributeModel>(new BusinessException(validationResults)));
                }

                var newEntity = this.mapper.Map<PropertyAttribute>(propertyAttribute);
                newEntity.UID = Guid.NewGuid().ToString();
                newEntity.CreatedBy = loggedInUser;
                newEntity.CreatedDate = DateTime.Now;
                newEntity.LastUpdatedBy = loggedInUser;
                newEntity.LastUpdatedDate = DateTime.Now;
                var flag = await this.repository.AddPropertyAttributeAsync(newEntity);
                if (flag)
                {
                    if (await this.uow.SaveChangesAsync() > 0)
                    {
                        var newModel = this.mapper.Map<PropertyAttributeModel>(newEntity);
                        return await Task.FromResult<Result<PropertyAttributeModel>>(new Result<PropertyAttributeModel>(newModel));
                    }
                    else
                    {
                        return await Task.FromResult<Result<PropertyAttributeModel>>(new Result<PropertyAttributeModel>(
                            new BusinessException(new ValidationModel("Unable to save the property attribute profile to database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<PropertyAttributeModel>>(new Result<PropertyAttributeModel>(
                        new BusinessException(new ValidationModel("Unable to save the property attribute profile to database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<PropertyAttributeModel>>(new Result<PropertyAttributeModel>(ex));
            }
        }

        public async Task<Result<PropertyListingModel>> CreatePropertyListingAsync(string loggedInUser, PropertyListingModel propertyListing)
        {
            try
            {
                var validationResults = await this.validator.ValidatePropertyListingAsync(loggedInUser, propertyListing);
                if (validationResults.Any())
                {
                    return await Task.FromResult<Result<PropertyListingModel>>(new Result<PropertyListingModel>(new BusinessException(validationResults)));
                }
                var newPropertyListingEntity = this.mapper.Map<PropertyListing>(propertyListing);
                newPropertyListingEntity.UID= Guid.NewGuid().ToString();
                newPropertyListingEntity.CreatedBy = loggedInUser;
                newPropertyListingEntity.CreatedDate= DateTime.Now;
                newPropertyListingEntity.LastUpdatedBy= loggedInUser;
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
                            new BusinessException(new ValidationModel("Unable to save the property listing profile to database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<PropertyListingModel>>(new Result<PropertyListingModel>(
                        new BusinessException(new ValidationModel("Unable to save the property listing profile to database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<PropertyListingModel>>(new Result<PropertyListingModel>(ex));
            }
        }

        public async Task<Result<PropertyListingAttributeModel>> CreatePropertyListingAttributeAsync(string loggedInUser, PropertyListingAttributeModel propertyListingAttribute)
        {
            try
            {
                var validationResults = await this.validator.ValidatePropertyListingAttributeAsync(loggedInUser, propertyListingAttribute);
                if (validationResults.Any())
                {
                    return await Task.FromResult<Result<PropertyListingAttributeModel>>(new Result<PropertyListingAttributeModel>(
                        new BusinessException(validationResults)));
                }

                var newEntity = this.mapper.Map<PropertyListingAttribute>(propertyListingAttribute);
                newEntity.UID = Guid.NewGuid().ToString();
                newEntity.CreatedBy = loggedInUser;
                newEntity.CreatedDate = DateTime.Now;
                newEntity.LastUpdatedBy = loggedInUser;
                newEntity.LastUpdatedDate = DateTime.Now;
                var flag = await this.repository.AddPropertyListingAttributeAsync(newEntity);
                if (flag)
                {
                    if (await this.uow.SaveChangesAsync() > 0)
                    {
                        var newModel = this.mapper.Map<PropertyListingAttributeModel>(newEntity);
                        return await Task.FromResult<Result<PropertyListingAttributeModel>>(new Result<PropertyListingAttributeModel>(newModel));
                    }
                    else
                    {
                        return await Task.FromResult<Result<PropertyListingAttributeModel>>(new Result<PropertyListingAttributeModel>(
                            new BusinessException(new ValidationModel("Unable to save the property listing attribute profile to database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<PropertyListingAttributeModel>>(new Result<PropertyListingAttributeModel>(
                        new BusinessException(new ValidationModel("Unable to save the property listing attribute profile to database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<PropertyListingAttributeModel>>(new Result<PropertyListingAttributeModel>(ex));
            }
        }

        public async Task<Result<PropertyViewingModel>> CreatePropertyViewing(string loggedInUser, PropertyViewingModel propertyViewingModel)
        {
            try
            {
                var validationResults = await this.validator.ValidatePropertyViewingAsync(loggedInUser, propertyViewingModel);
                if (validationResults.Any())
                {
                    return await Task.FromResult<Result<PropertyViewingModel>>(new Result<PropertyViewingModel>(new BusinessException(validationResults)));
                }
                var newPropertyViewingEntity = this.mapper.Map<PropertyViewing>(propertyViewingModel);
                newPropertyViewingEntity.UID = Guid.NewGuid().ToString();
                newPropertyViewingEntity.CreatedBy = loggedInUser;
                newPropertyViewingEntity.CreatedDate = DateTime.Now;
                newPropertyViewingEntity.LastUpdatedBy = loggedInUser;
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
                            new BusinessException(new ValidationModel("Unable to save the property viewing profile to database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<PropertyViewingModel>>(new Result<PropertyViewingModel>(
                        new BusinessException(new ValidationModel("Unable to save the property viewing profile to database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<PropertyViewingModel>>(new Result<PropertyViewingModel>(ex));
            }
        }

        public async Task<Result<bool>> DeleteAllPropertyImagesAsync(string loggedInUser, string propertyUID)
        {
            try
            {
                var existingImages = this.repository.GetAllPropertyImages().Where(x=>x.IsActive && x.PropertyUID==propertyUID).ToList<PropertyImage>();
                if (!existingImages.Any())
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(new BusinessException(new ValidationModel("The given property image doesn't have any pictures uploaded."))));
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
                            new BusinessException(new ValidationModel("Unable to delete the property image from database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(
                        new BusinessException(new ValidationModel("Unable to delete the property image from database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<bool>>(new Result<bool>(ex));
            }
        }

        public async Task<Result<bool>> DeletePropertyAsync(string loggedInUser, string propertyUID)
        {
            try
            {
                var existingProperty = this.repository.GetAllProperties().Where(x =>x.UID == propertyUID).FirstOrDefault<Property>();
                if (existingProperty==null)
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(new BusinessException(new ValidationModel("The given property profile doesn't exists."))));
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
                            new BusinessException(new ValidationModel("Unable to delete the property profile from database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(
                        new BusinessException(new ValidationModel("Unable to delete the property profile from database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<bool>>(new Result<bool>(ex));
            }
        }

        public async Task<Result<bool>> DeletePropertyAttributeAsync(string loggedInUser, string propertyAttributeUID)
        {
            try
            {
                var existingEntity = await this.repository.GetPropertyAttributeAsync(propertyAttributeUID);
                if (existingEntity == null)
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(new BusinessException(new ValidationModel("The given property attribute doesn't exists."))));
                }
                bool flag = await this.repository.DeletePropertyAttributeAsync(existingEntity);

                if (flag)
                {
                    if (await this.uow.SaveChangesAsync() > 0)
                    {
                        return await Task.FromResult<Result<bool>>(new Result<bool>(true));
                    }
                    else
                    {
                        return await Task.FromResult<Result<bool>>(new Result<bool>(
                            new BusinessException(new ValidationModel("Unable to delete the property attribute from database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(
                        new BusinessException(new ValidationModel("Unable to delete the property attribute from database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<bool>>(new Result<bool>(ex));
            }
        }

        public async Task<Result<bool>> DeletePropertyImageAsync(string loggedInUser, string propertyImageUID)
        {
            try
            {
                var existingPropertyImage = this.repository.GetAllPropertyImages().Where(x => x.UID == propertyImageUID).FirstOrDefault<PropertyImage>();
                if (existingPropertyImage == null)
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(new BusinessException(new ValidationModel("The given property image doesn't have any pictures uploaded."))));
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
                            new BusinessException(new ValidationModel("Unable to delete the property image from database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(
                        new BusinessException(new ValidationModel("Unable to delete the property image from database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<bool>>(new Result<bool>(ex));
            }
        }

        public async Task<Result<bool>> DeletePropertyListingAsync(string loggedInUser, string propertyListingUID)
        {
            try
            {
                var existingPropertyListing = this.repository.GetAllPropertyListings().Where(x => x.UID == propertyListingUID).FirstOrDefault<PropertyListing>();
                if (existingPropertyListing == null)
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(new BusinessException(new ValidationModel("The given property listing doesn't exist."))));
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
                            new BusinessException(new ValidationModel("Unable to delete the property listing from database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(
                        new BusinessException(new ValidationModel("Unable to delete the property listing from database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<bool>>(new Result<bool>(ex));
            }
        }

        public async Task<Result<bool>> DeletePropertyListingAttributeAsync(string loggedInUser, string propertyListingAttributeUID)
        {
            try
            {
                var existingEntity = await this.repository.GetPropertyListingAttributeAsync(propertyListingAttributeUID);
                if (existingEntity == null)
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(new BusinessException(new ValidationModel("The given property listing attribute doesn't exists."))));
                }
                bool flag = await this.repository.DeletePropertyListingAttributeAsync(existingEntity);

                if (flag)
                {
                    if (await this.uow.SaveChangesAsync() > 0)
                    {
                        return await Task.FromResult<Result<bool>>(new Result<bool>(true));
                    }
                    else
                    {
                        return await Task.FromResult<Result<bool>>(new Result<bool>(
                            new BusinessException(new ValidationModel("Unable to delete the property listing attribute from database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(
                        new BusinessException(new ValidationModel("Unable to delete the property listing attribute from database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<bool>>(new Result<bool>(ex));
            }
        }

        public async Task<Result<bool>> DeletePropertyViewing(string loggedInUser, string propertyViewingUID)
        {
            try
            {
                var existingPropertyViewing = this.repository.GetAllPropertyViewings().Where(x => x.UID == propertyViewingUID).FirstOrDefault<PropertyViewing>();
                if (existingPropertyViewing == null)
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(new BusinessException(new ValidationModel("The given property viewing doesn't exist."))));
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
                            new BusinessException(new ValidationModel("Unable to delete the property viewing from database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(
                        new BusinessException(new ValidationModel("Unable to delete the property viewing from database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<bool>>(new Result<bool>(ex));
            }
        }

        public async Task<Result<PropertyImageModel[]>> GetAllPropertyImagesAsync(string loggedInUser, string propertyUID)
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

        public async Task<Result<List<PropertyListingModel>>> GetAllPropertyListingsAsync(string loggedInUser, string landlordProfileUID)
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

        public async Task<Result<List<PropertyListingModel>>> GetAllPropertyListingsByFilterAsync(string loggedInUser, PropertyListingFilterModel filter)
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

        public async Task<Result<List<PropertyViewingModel>>> GetAllPropertyViewingsByLandlordAsync(string loggedInUser, string landlordUID)
        {
            try
            {
                var viewings = new List<PropertyViewing>();
                var property = this.repository.GetAllProperties().Where(x => x.LandlordProfileUID == landlordUID).FirstOrDefault();
                if (property != null)
                {
                    var listings = property.Listings;
                    if(listings != null)
                    {
                        
                        foreach (var listing in listings)
                        {
                            if (listing.Viewings != null)
                            {
                                viewings.AddRange(listing.Viewings);
                            }                           
                        }
                    }
                }
                var model = this.mapper.Map<List<PropertyViewingModel>>(viewings);
                return await Task.FromResult<Result<List<PropertyViewingModel>>>(new Result<List<PropertyViewingModel>>(model));
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<List<PropertyViewingModel>>>(new Result<List<PropertyViewingModel>>(ex));
            }
        }

        public async Task<Result<List<PropertyViewingModel>>> GetAllPropertyViewingsByTenantAsync(string loggedInUser, string tenantUID)
        {
            try
            {

                var viewings = this.repository.GetAllPropertyViewings().Where(x => x.TenantUID == tenantUID && x.IsActive).ToList<PropertyViewing>();
                if (viewings == null)
                {
                    viewings = new List<PropertyViewing>();
                }
                var model = this.mapper.Map<List<PropertyViewingModel>>(viewings);
                return await Task.FromResult<Result<List<PropertyViewingModel>>>(new Result<List<PropertyViewingModel>>(model));
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<List<PropertyViewingModel>>>(new Result<List<PropertyViewingModel>>(ex));
            }
        }

        public async Task<Result<List<PropertyModel>>> GetPropertiesByLandlordAsync(string loggedInUser, string landlordProfileUID)
        {
            try
            {

                var properties = this.repository.GetAllProperties().Where(x => x.LandlordProfileUID == landlordProfileUID && x.IsActive).ToList<Property>();
                if (properties == null)
                {
                    properties = new List<Property>();
                }
                var model = this.mapper.Map<List<PropertyModel>>(properties);
                return await Task.FromResult<Result<List<PropertyModel>>>(new Result<List<PropertyModel>>(model));
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<List<PropertyModel>>>(new Result<List<PropertyModel>>(ex));
            }
        }

        public async Task<Result<PropertyModel>> GetPropertyByUIDAsync(string loggedInUser, string propertyUID)
        {
            try
            {

                var property = this.repository.GetAllProperties().Where(x => x.UID == propertyUID && x.IsActive).ToList<Property>();
                var model = this.mapper.Map<PropertyModel>(property);
                return await Task.FromResult<Result<PropertyModel>>(new Result<PropertyModel>(model));
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<PropertyModel>>(new Result<PropertyModel>(ex));
            }
        }

        public async Task<Result<PropertyAttributeModel>> GetPropertyAttributeByUIDAsync(string loggedInUser, string propertyAttributeUID)
        {
            try
            {

                var entity = this.repository.GetAllPropertyAttributes().Where(x => x.UID == propertyAttributeUID && x.IsActive).FirstOrDefault();
                var model = this.mapper.Map<PropertyAttributeModel>(entity);
                return await Task.FromResult<Result<PropertyAttributeModel>>(new Result<PropertyAttributeModel>(model));
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<PropertyAttributeModel>>(new Result<PropertyAttributeModel>(ex));
            }
        }

        public async Task<Result<PropertyAttributeModel>> GetPropertyAttributeByPropertyAsync(string loggedInUser, string propertyUID)
        {
            try
            {
                var entity = this.repository.GetAllPropertyAttributes().Where(x => x.PropertyUID == propertyUID && x.IsActive).FirstOrDefault();
                var model = this.mapper.Map<PropertyAttributeModel>(entity);
                return await Task.FromResult<Result<PropertyAttributeModel>>(new Result<PropertyAttributeModel>(model));
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<PropertyAttributeModel>>(new Result<PropertyAttributeModel>(ex));
            }
        }

        public async Task<Result<PropertyAttributeModel[]>> GetAllPropertyAttributesByPropertyAsync(string loggedInUser, string propertyUID)
        {
            try
            {

                var entities = this.repository.GetAllPropertyAttributes().Where(x => x.PropertyUID == propertyUID).ToArray();
                var model = this.mapper.Map<PropertyAttributeModel[]>(entities);
                return await Task.FromResult<Result<PropertyAttributeModel[]>>(new Result<PropertyAttributeModel[]>(model));
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<PropertyAttributeModel[]>>(new Result<PropertyAttributeModel[]>(ex));
            }
        }

        public async Task<Result<PropertyListingModel>> GetPropertyListingByUIDAsync(string loggedInUser, string propertyListingUID)
        {
            try
            {
                var propertyListing = this.repository.GetAllPropertyListings().Where(x=>x.UID==propertyListingUID).FirstOrDefault<PropertyListing>();
                var model = this.mapper.Map<PropertyListingModel>(propertyListing);
                return await Task.FromResult<Result<PropertyListingModel>>(new Result<PropertyListingModel>(model));
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<PropertyListingModel>>(new Result<PropertyListingModel>(ex));
            }
        }

        public async Task<Result<PropertyListingAttributeModel>> GetPropertyListingAttributeAsync(string loggedInUser, string propertyListingAttributeUID)
        {
            try
            {

                var entity = this.repository.GetAllPropertyListingAttributes().Where(x => x.UID == propertyListingAttributeUID && x.IsActive).FirstOrDefault();
                var model = this.mapper.Map<PropertyListingAttributeModel>(entity);
                return await Task.FromResult<Result<PropertyListingAttributeModel>>(new Result<PropertyListingAttributeModel>(model));
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<PropertyListingAttributeModel>>(new Result<PropertyListingAttributeModel>(ex));
            }
        }

        public async Task<Result<PropertyListingAttributeModel>> GetPropertyListingAttributeByListingUIDAsync(string loggedInUser, string propertyListingUID)
        {
            try
            {

                var entity = this.repository.GetAllPropertyListingAttributes().Where(x => x.PropertyListingUID == propertyListingUID && x.IsActive).FirstOrDefault();
                var model = this.mapper.Map<PropertyListingAttributeModel>(entity);
                return await Task.FromResult<Result<PropertyListingAttributeModel>>(new Result<PropertyListingAttributeModel>(model));
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<PropertyListingAttributeModel>>(new Result<PropertyListingAttributeModel>(ex));
            }
        }

        public async Task<Result<PropertyListingAttributeModel[]>> GetAllPropertyListingAttributesByListingUIDAsync(string loggedInUser, string propertyListingUID)
        {
            try
            {

                var entities = this.repository.GetAllPropertyListingAttributes().Where(x => x.PropertyListingUID == propertyListingUID).ToArray();
                var model = this.mapper.Map<PropertyListingAttributeModel[]>(entities);
                return await Task.FromResult<Result<PropertyListingAttributeModel[]>>(new Result<PropertyListingAttributeModel[]>(model));
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<PropertyListingAttributeModel[]>>(new Result<PropertyListingAttributeModel[]>(ex));
            }
        }

        public async Task<Result<PropertyModel>> UpdatePropertyAsync(string loggedInUser, PropertyModel property)
        {
            try
            {
                var validationResults = await this.validator.ValidatePropertyAsync(loggedInUser, property);
                if (validationResults.Any())
                {
                    return await Task.FromResult<Result<PropertyModel>>(new Result<PropertyModel>(new BusinessException(validationResults)));
                }
                var existingProperty = await this.repository.GetPropertyAsync(property.UID);
                if (existingProperty == null)
                {
                    return await Task.FromResult<Result<PropertyModel>>(new Result<PropertyModel>(new BusinessException(new ValidationModel("The Property profile doesn't exists."))));
                }
                var updatedPropertyEntity=this.mapper.Map<PropertyModel,Property>(property,existingProperty);
                updatedPropertyEntity.LastUpdatedBy= loggedInUser;
                updatedPropertyEntity.LastUpdatedDate= DateTime.Now;    
                var flag=await this.repository.UpdatePropertyAsync(updatedPropertyEntity);
                if (flag)
                {
                    if (await this.uow.SaveChangesAsync() > 0)
                    {
                        return await Task.FromResult<Result<PropertyModel>>(new Result<PropertyModel>(property));
                    }
                    else
                    {
                        return await Task.FromResult<Result<PropertyModel>>(new Result<PropertyModel>(
                            new BusinessException(new ValidationModel("Unable to update the property profile to database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<PropertyModel>>(new Result<PropertyModel>(
                        new BusinessException(new ValidationModel("Unable to update the property profile to database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<PropertyModel>>(new Result<PropertyModel>(ex));
            }
        }

        public async Task<Result<PropertyAttributeModel>> UpdatePropertyAttributeAsync(string loggedInUser, PropertyAttributeModel propertyAttribute)
        {
            try
            {
                var validationResults = await this.validator.ValidatePropertyAttributeAsync(loggedInUser, propertyAttribute);
                if (validationResults.Any())
                {
                    return await Task.FromResult<Result<PropertyAttributeModel>>(new Result<PropertyAttributeModel>(new BusinessException(validationResults)));
                }
                var existingEntity = await this.repository.GetPropertyAttributeAsync(propertyAttribute.UID);
                if (existingEntity == null)
                {
                    return await Task.FromResult<Result<PropertyAttributeModel>>(new Result<PropertyAttributeModel>(new BusinessException(new ValidationModel("The Property profile doesn't exists."))));
                }
                var updatedEntity = this.mapper.Map<PropertyAttributeModel, PropertyAttribute>(propertyAttribute, existingEntity);
                updatedEntity.LastUpdatedBy = loggedInUser;
                updatedEntity.LastUpdatedDate = DateTime.Now;
                var flag = await this.repository.UpdatePropertyAttributeAsync(updatedEntity);
                if (flag)
                {
                    if (await this.uow.SaveChangesAsync() > 0)
                    {
                        return await Task.FromResult<Result<PropertyAttributeModel>>(new Result<PropertyAttributeModel>(propertyAttribute));
                    }
                    else
                    {
                        return await Task.FromResult<Result<PropertyAttributeModel>>(new Result<PropertyAttributeModel>(
                            new BusinessException(new ValidationModel("Unable to update the property attribute to database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<PropertyAttributeModel>>(new Result<PropertyAttributeModel>(
                        new BusinessException(new ValidationModel("Unable to update the property attribute to database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<PropertyAttributeModel>>(new Result<PropertyAttributeModel>(ex));
            }
        }

        public async Task<Result<PropertyListingModel>> UpdatePropertyListing(string loggedInUser, PropertyListingModel propertyListing)
        {
            try
            {
                var validationResults = await this.validator.ValidatePropertyListingAsync(loggedInUser, propertyListing);
                if (validationResults.Any())
                {
                    return await Task.FromResult<Result<PropertyListingModel>>(new Result<PropertyListingModel>(new BusinessException(validationResults)));
                }
                var existingPropertyListing = await this.repository.GetPropertyListingAsync(propertyListing.UID);
                if (existingPropertyListing == null)
                {
                    return await Task.FromResult<Result<PropertyListingModel>>(new Result<PropertyListingModel>(new BusinessException(new ValidationModel("The Property profile doesn't exists."))));
                }
                var updatedPropertyListingEntity = this.mapper.Map<PropertyListingModel,PropertyListing>(propertyListing,existingPropertyListing);
                updatedPropertyListingEntity.LastUpdatedBy = loggedInUser;
                updatedPropertyListingEntity.LastUpdatedDate = DateTime.Now;    
                var flag = await this.repository.UpdatePropertyListingAsync(updatedPropertyListingEntity);
                if (flag)
                {
                    if (await this.uow.SaveChangesAsync() > 0)
                    {
                        return await Task.FromResult<Result<PropertyListingModel>>(new Result<PropertyListingModel>(propertyListing));
                    }
                    else
                    {
                        return await Task.FromResult<Result<PropertyListingModel>>(new Result<PropertyListingModel>(
                            new BusinessException(new ValidationModel("Unable to update the property listing profile to database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<PropertyListingModel>>(new Result<PropertyListingModel>(
                        new BusinessException(new ValidationModel("Unable to update the property listing profile to database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<PropertyListingModel>>(new Result<PropertyListingModel>(ex));
            }
        }

        public async Task<Result<PropertyListingAttributeModel>> UpdatePropertyListingAttributeAsync(string loggedInUser, PropertyListingAttributeModel propertyListingAttribute)
        {
            try
            {
                var validationResults = await this.validator.ValidatePropertyListingAttributeAsync(loggedInUser, propertyListingAttribute);
                if (validationResults.Any())
                {
                    return await Task.FromResult<Result<PropertyListingAttributeModel>>(new Result<PropertyListingAttributeModel>(new BusinessException(validationResults)));
                }
                var existingEntity = await this.repository.GetPropertyListingAttributeAsync(propertyListingAttribute.UID);
                if (existingEntity == null)
                {
                    return await Task.FromResult<Result<PropertyListingAttributeModel>>(new Result<PropertyListingAttributeModel>(new BusinessException(new ValidationModel("The Property profile doesn't exists."))));
                }
                var updatedEntity = this.mapper.Map<PropertyListingAttributeModel, PropertyListingAttribute>(propertyListingAttribute, existingEntity);
                updatedEntity.LastUpdatedBy = loggedInUser;
                updatedEntity.LastUpdatedDate = DateTime.Now;
                var flag = await this.repository.UpdatePropertyListingAttributeAsync(updatedEntity);
                if (flag)
                {
                    if (await this.uow.SaveChangesAsync() > 0)
                    {
                        return await Task.FromResult<Result<PropertyListingAttributeModel>>(new Result<PropertyListingAttributeModel>(propertyListingAttribute));
                    }
                    else
                    {
                        return await Task.FromResult<Result<PropertyListingAttributeModel>>(new Result<PropertyListingAttributeModel>(
                            new BusinessException(new ValidationModel("Unable to update the property listing attribute to database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<PropertyListingAttributeModel>>(new Result<PropertyListingAttributeModel>(
                        new BusinessException(new ValidationModel("Unable to update the property listing attribute to database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<PropertyListingAttributeModel>>(new Result<PropertyListingAttributeModel>(ex));
            }
        }

        public async Task<Result<PropertyViewingModel>> UpdatePropertyViewingAsync(string loggedInUser, PropertyViewingModel propertyViewingModel)
        {
            try
            {
                var validationResults = await this.validator.ValidatePropertyViewingAsync(loggedInUser, propertyViewingModel);
                if (validationResults.Any())
                {
                    return await Task.FromResult<Result<PropertyViewingModel>>(new Result<PropertyViewingModel>(new BusinessException(validationResults)));
                }
                var existingPropertyViewing = await this.repository.GetPropertyViewingAsync(propertyViewingModel.UID);
                if (existingPropertyViewing == null)
                {
                    return await Task.FromResult<Result<PropertyViewingModel>>(new Result<PropertyViewingModel>(new BusinessException(new ValidationModel("The Property profile doesn't exists."))));
                }
                var updatedPropertyViewingEntity = this.mapper.Map<PropertyViewingModel,PropertyViewing>(propertyViewingModel, existingPropertyViewing);
                updatedPropertyViewingEntity.LastUpdatedBy = loggedInUser;
                updatedPropertyViewingEntity.LastUpdatedDate = DateTime.Now;    
                var flag = await this.repository.UpdatePropertyViewingAsync(updatedPropertyViewingEntity);
                if (flag)
                {
                    if (await this.uow.SaveChangesAsync() > 0)
                    {
                        return await Task.FromResult<Result<PropertyViewingModel>>(new Result<PropertyViewingModel>(propertyViewingModel));
                    }
                    else
                    {
                        return await Task.FromResult<Result<PropertyViewingModel>>(new Result<PropertyViewingModel>(
                            new BusinessException(new ValidationModel("Unable to update the property viewing profile to database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<PropertyViewingModel>>(new Result<PropertyViewingModel>(
                        new BusinessException(new ValidationModel("Unable to update the property viewing profile to database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<PropertyViewingModel>>(new Result<PropertyViewingModel>(ex));
            }
        }

        public async Task<Result<bool>> CreatePropertyImageAsync(string loggedInUser, PropertyImageModel model)
        {
            try
            {

                var validationResults = await this.validator.ValidatePropertyImageAsync(loggedInUser, model);

                if (validationResults.Any())
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(new BusinessException(validationResults)));
                }
                var propertyImagingEntity = this.mapper.Map<PropertyImage>(model);
                propertyImagingEntity.UID = Guid.NewGuid().ToString();
                propertyImagingEntity.ImageFileUID = model.ImageFileUID;
                propertyImagingEntity.CreatedBy = loggedInUser;
                propertyImagingEntity.CreatedDate = DateTime.Now;
                propertyImagingEntity.LastUpdatedBy = loggedInUser;
                propertyImagingEntity.LastUpdatedDate = DateTime.Now;
                var flag = await this.repository.AddPropertyImageAsync(propertyImagingEntity);
                if (flag)
                {
                    if (await this.uow.SaveChangesAsync() > 0)
                    {
                        return await Task.FromResult<Result<bool>>(new Result<bool>(true));
                    }
                    else
                    {
                        return await Task.FromResult<Result<bool>>(new Result<bool>(false));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(false));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<bool>>(new Result<bool>(ex));
            }
        }

        public async Task<Result<PropertyRentingModel>> CreatePropertyRentingAsync(string loggedInUser, PropertyRentingModel propertyRentingModel)
        {
            try
            {
                var validationResults = await this.validator.ValidatePropertyRentingAsync(loggedInUser, propertyRentingModel);
                if (validationResults.Any())
                {
                    return await Task.FromResult<Result<PropertyRentingModel>>(new Result<PropertyRentingModel>(new BusinessException(validationResults)));
                }

                var newPropertyRentingEntity = this.mapper.Map<PropertyRenting>(propertyRentingModel);
                newPropertyRentingEntity.UID = Guid.NewGuid().ToString();
                newPropertyRentingEntity.CreatedBy = loggedInUser;
                newPropertyRentingEntity.CreatedDate = DateTime.Now;
                newPropertyRentingEntity.LastUpdatedBy = loggedInUser;
                newPropertyRentingEntity.LastUpdatedDate = DateTime.Now;
                var flag = await this.repository.AddPropertyRentingAsync(newPropertyRentingEntity);
                if (flag)
                {
                    if (await this.uow.SaveChangesAsync() > 0)
                    {
                        var newPropertyRentingModel = this.mapper.Map<PropertyRentingModel>(newPropertyRentingEntity);
                        return await Task.FromResult<Result<PropertyRentingModel>>(new Result<PropertyRentingModel>(newPropertyRentingModel));
                    }
                    else
                    {
                        return await Task.FromResult<Result<PropertyRentingModel>>(new Result<PropertyRentingModel>(
                            new BusinessException(new ValidationModel("Unable to save the property renting profile to database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<PropertyRentingModel>>(new Result<PropertyRentingModel>(
                        new BusinessException(new ValidationModel("Unable to save the property renting profile to database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<PropertyRentingModel>>(new Result<PropertyRentingModel>(ex));
            }
        }
        public async Task<Result<PropertyRentingModel>> UpdatePropertyRentingAsync(string loggedInUser, PropertyRentingModel propertyRentingModel)
        {
            try
            {
                var validationResults = await this.validator.ValidatePropertyRentingAsync(loggedInUser, propertyRentingModel);
                if (validationResults.Any())
                {
                    return await Task.FromResult<Result<PropertyRentingModel>>(new Result<PropertyRentingModel>(new BusinessException(validationResults)));
                }
                var existingPropertyRenting = await this.repository.GetPropertyRentingAsync(propertyRentingModel.UID);
                if (existingPropertyRenting == null)
                {
                    return await Task.FromResult<Result<PropertyRentingModel>>(new Result<PropertyRentingModel>(new BusinessException(new ValidationModel("The Property profile doesn't exists."))));
                }
                var updatedPropertyRentingEntity = this.mapper.Map<PropertyRentingModel,PropertyRenting>(propertyRentingModel,existingPropertyRenting);
                updatedPropertyRentingEntity.LastUpdatedBy= loggedInUser;
                updatedPropertyRentingEntity.LastUpdatedDate= DateTime.Now; 
                var flag = await this.repository.UpdatePropertyRentingAsync(updatedPropertyRentingEntity);
                if (flag)
                {
                    if (await this.uow.SaveChangesAsync() > 0)
                    {
                       
                        return await Task.FromResult<Result<PropertyRentingModel>>(new Result<PropertyRentingModel>(propertyRentingModel));
                    }
                    else
                    {
                        return await Task.FromResult<Result<PropertyRentingModel>>(new Result<PropertyRentingModel>(
                            new BusinessException(new ValidationModel("Unable to update the property renting profile to database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<PropertyRentingModel>>(new Result<PropertyRentingModel>(
                        new BusinessException(new ValidationModel("Unable to update the property renting profile to database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<PropertyRentingModel>>(new Result<PropertyRentingModel>(ex));
            }
        }
        public async Task<Result<List<PropertyRentingModel>>> GetAllPropertyRentingsByLandlordAsync(string loggedInUser, string landlordProfileUID)
        {
            try
            {
                var propertyRentings = new List<PropertyRenting>();
                var properties = this.repository.GetAllProperties().Where(x => x.LandlordProfileUID == landlordProfileUID && x.IsActive).ToList<Property>();
                if (properties != null)
                {
                    foreach (var property in properties)
                    {
                        if (property.Listings != null)
                        {
                            foreach (var listing in property.Listings)
                            {
                                if(listing.Rentings != null)
                                {
                                    propertyRentings.AddRange(listing.Rentings);
                                }
                            }
                        }
                    }
                }
                var model = this.mapper.Map<List<PropertyRentingModel>>(propertyRentings);
                return await Task.FromResult<Result<List<PropertyRentingModel>>>(new Result<List<PropertyRentingModel>>(model));
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<List<PropertyRentingModel>>>(new Result<List<PropertyRentingModel>>(ex));
            }
        }
        public async Task<Result<List<PropertyRentingModel>>> GetAllPropertyRentingsByTenantAsync(string loggedInUser, string tenantUID)
        {
            try
            {
                var tenant = await this.uow.TenantRepository.GetTenantAsync(tenantUID);
                if(tenant == null)
                {
                    return await Task.FromResult<Result<List<PropertyRentingModel>>>(new Result<List<PropertyRentingModel>>(
                            new BusinessException(new ValidationModel("The given tenant profile doesn't exists."))));
                }
                var propertyRentings = this.repository.GetAllPropertyRentings().Where(x => x.TenantUID == tenantUID).ToList<PropertyRenting>();
                if (propertyRentings == null)
                {
                    propertyRentings = new List<PropertyRenting>();
                }
                var model = this.mapper.Map<List<PropertyRentingModel>>(propertyRentings);
                return await Task.FromResult<Result<List<PropertyRentingModel>>>(new Result<List<PropertyRentingModel>>(model));
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<List<PropertyRentingModel>>>(new Result<List<PropertyRentingModel>>(ex));
            }
        }
        public async Task<Result<List<PropertyRentingModel>>> GetAllActivePropertyRentingsByLandlordAsync(string loggedInUser, string landlordProfileUID)
        {
            try
            {
                var propertyRentingResults = await GetAllPropertyRentingsByLandlordAsync(loggedInUser, landlordProfileUID);
                var activeRentings = propertyRentingResults.Value.FindAll(x => x.IsActive);
                return await Task.FromResult<Result<List<PropertyRentingModel>>>(new Result<List<PropertyRentingModel>>(activeRentings));
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<List<PropertyRentingModel>>>(new Result<List<PropertyRentingModel>>(ex));
            }
        }
        public async Task<Result<List<PropertyRentingModel>>> GetAllActivePropertyRentingsByTenantAsync(string loggedInUser, string tenantUID)
        {
            try
            {
                var propertyRentingResults = await GetAllPropertyRentingsByTenantAsync(loggedInUser, tenantUID);
                var activeRentings = propertyRentingResults.Value.FindAll(x => x.IsActive);
                return await Task.FromResult<Result<List<PropertyRentingModel>>>(new Result<List<PropertyRentingModel>>(activeRentings));
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<List<PropertyRentingModel>>>(new Result<List<PropertyRentingModel>>(ex));
            }
        }
        public async Task<Result<List<PropertyRentingModel>>> GetAllPropertyRentingByPropertyUIDAsync(string loggedInUser, string propertyUID)
        {
            try
            {
                var propertyRentings = new List<PropertyRenting>();
                var property = this.repository.GetAllProperties().Where(x => x.UID == propertyUID && x.IsActive).FirstOrDefault<Property>();

                if (property != null && property.Listings != null)
                {
                    foreach (var listing in property.Listings)
                    {
                        if (listing.Rentings != null)
                        {
                            propertyRentings.AddRange(listing.Rentings);
                        }
                    }
                }

                var model = this.mapper.Map<List<PropertyRentingModel>>(propertyRentings);
                return await Task.FromResult<Result<List<PropertyRentingModel>>>(new Result<List<PropertyRentingModel>>(model));
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<List<PropertyRentingModel>>>(new Result<List<PropertyRentingModel>>(ex));
            }
        }

        public async Task<Result<PropertyRentingModel>> GetActivePropertyRentingByPropertyUIDAsync(string loggedInUser, string propertyUID)
        {
            try
            {
                var propertyRentingResults = await GetAllPropertyRentingByPropertyUIDAsync(loggedInUser, propertyUID);
                var activeRenting = propertyRentingResults.Value.Find(x => x.IsActive);
                return await Task.FromResult<Result<PropertyRentingModel>>(new Result<PropertyRentingModel>(activeRenting));
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<PropertyRentingModel>>(new Result<PropertyRentingModel>(ex));
            }
        }

        public async Task<Result<bool>> DeletePropertyRentingAsync(string loggedInUser, string propertyRentingUID)
        {
            try
            {
                var existingPropertyRenting = this.repository.GetAllPropertyRentings().Where(x => x.UID == propertyRentingUID).FirstOrDefault<PropertyRenting>();
                if (existingPropertyRenting == null)
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(new BusinessException(new ValidationModel("The given property renting profile doesn't exists."))));
                }
                bool flag = await this.repository.DeletePropertyRentingAsync(existingPropertyRenting);

                if (flag)
                {
                    if (await this.uow.SaveChangesAsync() > 0)
                    {
                        return await Task.FromResult<Result<bool>>(new Result<bool>(true));
                    }
                    else
                    {
                        return await Task.FromResult<Result<bool>>(new Result<bool>(
                            new BusinessException(new ValidationModel("Unable to delete the property renting profile from database."))));
                    }
                }
                else
                {
                    return await Task.FromResult<Result<bool>>(new Result<bool>(
                        new BusinessException(new ValidationModel("Unable to delete the property renting profile from database."))));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult<Result<bool>>(new Result<bool>(ex));
            }
        }
    }
}
