

namespace Business.Validators
{
    public class PropertyValidator :ValidatorBase, IPropertyValidator
    {
        private readonly IUnitOfWork uow;
        private readonly IUserRepository userRepo;
        private readonly ILandlordRepository landlordRepo;
        private readonly IPropertyRepository propertyRepo;
        private readonly IPropertyTypeRepository propertyTypeRepo;
        private readonly IFurnishTypeRepository furnishTypeRepo;

        public PropertyValidator(IUnitOfWork uow):base(uow)
        {
            this.uow = uow;
            this.userRepo = this.uow.UserRepository;
            this.landlordRepo = this.uow.LandlordRepository;
            this.propertyRepo = this.uow.PropertyRepository;
            this.propertyTypeRepo = this.uow.PropertyTypeRepository;
            this.furnishTypeRepo = this.uow.FurnishTypeRepository;
        }

        private bool IsPropertyExists(string propertyUID)
        {
            return this.propertyRepo.GetAllProperties().Where(p=>p.UID == propertyUID).Any();   
        }


        private bool IsPropertyTypeExists(int propertyTypeUID)
        {
            return this.propertyTypeRepo.GetAllPropertyTypes().Where(p => p.UID == propertyTypeUID).Any();
        }

        private bool IsFurnishTypeExists(int furnishTypeUID)
        {
            return this.furnishTypeRepo.GetAllFurnishTypes().Where(p => p.UID == furnishTypeUID).Any();
        }

        public async Task<List<ValidationModel>> ValidatePropertyAsync(string loggedInUser, PropertyModel model)
        {
            var validationResults = new List<ValidationModel>();

            if (loggedInUser == null)
            {
                validationResults.Add(new ValidationModel("Invalid LoggedIn user."));
            }
            var landLord = await this.landlordRepo.GetLandlordByProfileAsync(model.LandlordUID);
            if (landLord == null)
            {
                validationResults.Add(new ValidationModel("The given landlord profile doesn't exists."));
            }
            else 
            {
                var user=await this.userRepo.GetUserByUIDAsync(landLord.UserUID);
                if(user == null)
                {
                    validationResults.Add(new ValidationModel("The given landlord user doesn't exists."));
                }
                else
                {
                    if(
                        (!string.Equals(user.Role.Name,RoleConstant.Admin) && !string.Equals(user.Role.Name, RoleConstant.Consultant)) &&
                         !string.Equals(loggedInUser, user.UID)
                        )
                    {
                        validationResults.Add(new ValidationModel("LoggedIn user doesnt match with landlord user given in model."));
                    }
                }
                
            }
            if (string.IsNullOrEmpty(model.Address))
            {
                validationResults.Add(new ValidationModel("Address is a mandatory field."));
            }
            if (!IsCountryValid(model.CountryUID))
            {
                validationResults.Add(new ValidationModel("CountryUID is a not having a valid value."));
            }
            if (string.IsNullOrEmpty(model.Name))
            {
                validationResults.Add(new ValidationModel("Name is a mandatory field."));
            }
            if (string.IsNullOrEmpty(model.LandlordUID))
            {
                validationResults.Add(new ValidationModel("Lanlord profile UID is a mandatory field."));
            }
            return await Task.FromResult<List<ValidationModel>>(validationResults);
        }

        public async Task<List<ValidationModel>> ValidatePropertyAttributeAsync(string loggedInUser, PropertyAttributeModel model)
        {
            var validationResults = new List<ValidationModel>();

            if (loggedInUser == null)
            {
                validationResults.Add(new ValidationModel("Invalid LoggedIn user."));
            }
            if (string.IsNullOrEmpty(model.PropertyUID))
            {
                validationResults.Add(new ValidationModel("PropertyUID is a mandatory field."));
            }
            else
            {
                if (!IsPropertyExists(model.PropertyUID))
                {
                    validationResults.Add(new ValidationModel("The given property doesn't exists."));
                }
            }
            if (!IsPropertyTypeExists(model.PropertyTypeUID))
            {
                validationResults.Add(new ValidationModel("The given property type doesn't exists."));
            }
            if (!IsFurnishTypeExists(model.FurnishTypeUID))
            {
                validationResults.Add(new ValidationModel("The given furnish type doesn't exists."));
            }
            if (model.IsParkingSlotAvailable)
            {
                if (model.ParkingSlotCount <= 0)
                {
                    validationResults.Add(new ValidationModel("ParkingSlotCount value should be greater than one."));

                }                
            }
            else
            {
                if (model.ParkingSlotCount > 0)
                {
                    validationResults.Add(new ValidationModel("IsParkingSlotAvailable value should be enabled."));

                }
            }
            return await Task.FromResult<List<ValidationModel>>(validationResults);
        }

        public async Task<List<ValidationModel>> ValidatePropertyListingAsync(string loggedInUser, PropertyListingModel model)
        {
            var validationResults = new List<ValidationModel>();

            if (loggedInUser == null)
            {
                validationResults.Add(new ValidationModel("Invalid LoggedIn user."));
            }
            var property = await this.propertyRepo.GetPropertyAsync(model.PropertyUID);
            if (property==null)
            {
                validationResults.Add(new ValidationModel("The given property profile doesn't exists."));
            }
            else
            {
                var landLord = await this.landlordRepo.GetLandlordByProfileAsync(property.LandlordUID);
                if (landLord == null)
                {
                    validationResults.Add(new ValidationModel("The given landlord profile doesn't exists."));
                }
                else
                {
                    var user = await this.userRepo.GetUserByUIDAsync(landLord.UserUID);
                    if (user == null)
                    {
                        validationResults.Add(new ValidationModel("The given landlord user doesn't exists."));
                    }
                    else
                    {
                        if (
                            (!string.Equals(user.Role.Name, RoleConstant.Admin) && !string.Equals(user.Role.Name, RoleConstant.Consultant)) &&
                             !string.Equals(loggedInUser, user.UID)
                            )
                        {
                            validationResults.Add(new ValidationModel("LoggedIn user doesnt match with landlord user given in model."));
                        }
                    }

                }
            }

            //if (!Enum.IsDefined(typeof(ListingStatus), model.ListingStatus))
            //{
            //    validationResults.Add(new ValidationModel("ListingStatus contains invalid value."));
            //}
            if (model.ListingAmount<0)
            {
                validationResults.Add(new ValidationModel("ListingAmount should have a valid amount(>0)."));
            }
            return await Task.FromResult<List<ValidationModel>>(validationResults);
        }
        public async Task<List<ValidationModel>> ValidatePropertyListingAttributeAsync(string loggedInUser, PropertyListingAttributeModel model)
        {
            var validationResults = new List<ValidationModel>();

            if (loggedInUser == null)
            {
                validationResults.Add(new ValidationModel("Invalid LoggedIn user."));
            }
            var propertyListing = await this.propertyRepo.GetPropertyListingAsync(model.PropertyListingUID);
            if (propertyListing == null)
            {
                validationResults.Add(new ValidationModel("The parent property listing profile doesn't exists for this property listing attribute."));
            }
            else
            {
                var property = await this.propertyRepo.GetPropertyAsync(propertyListing.PropertyUID);
                if(property == null)
                {
                    validationResults.Add(new ValidationModel("The property for which listing attributes is mentioned doesn't exists."));
                }
                else
                {
                    var landlord = await this.landlordRepo.GetLandlordByProfileAsync(property.LandlordUID);
                    var role = this.GetRole(loggedInUser);
                    if (landlord == null)
                    {
                        validationResults.Add(new ValidationModel("The landlord for the property whose listing attributes mentioned doesn't exists."));
                    }
                    else
                    {
                        if (
                            (!string.Equals(role, RoleConstant.Admin) && !string.Equals(role, RoleConstant.Consultant)) &&
                             !string.Equals(loggedInUser, landlord.UserUID)
                            )
                        {
                            validationResults.Add(new ValidationModel("LoggedIn user doesnt match with landlord user given in model."));
                        }
                    }

                }

            }
            if (string.IsNullOrEmpty(model.PropertyAttributeUID))
            {
                validationResults.Add(new ValidationModel("The given PropertyAttributeUID  value is InValid."));
            }
            else
            {
                var propertyAttribute = this.propertyRepo.GetAllPropertyAttributes().Where(x => x.UID == model.PropertyAttributeUID).FirstOrDefault();
                if (propertyAttribute==null)
                {
                    validationResults.Add(new ValidationModel("The given PropertyAttributeUID  doesn't exists."));
                }

                if (model.AvailableBedroomCount> propertyAttribute.BedroomCount)
                {
                    validationResults.Add(
                        new ValidationModel($"The given AvailableBedroomCount  should be less than or equal to {propertyAttribute.BedroomCount.ToString()}."));
                }
                if (model.AvailableBathroomCount > propertyAttribute.BathroomCount)
                {
                    validationResults.Add(
                        new ValidationModel($"The given AvailableBathroomCount  should be less than or equal to {propertyAttribute.BathroomCount.ToString()}."));
                }
                if (model.AllowedOccupantCount > propertyAttribute.MaxOccupantCount)
                {
                    validationResults.Add(
                        new ValidationModel($"The given AllowedOccupantCount  should be less than or equal to {propertyAttribute.MaxOccupantCount.ToString()}."));
                }

                if (model.AvailableParkingSlots > propertyAttribute.ParkingSlotCount)
                {
                    validationResults.Add(
                        new ValidationModel($"The given AvailableParkingSlots  should be less than or equal to {propertyAttribute.BedroomCount.ToString()}."));
                }

                if (model.IsParkingAvailable && !propertyAttribute.IsParkingSlotAvailable)
                {
                    validationResults.Add(
                        new ValidationModel($"The Property doesn't have parking availability and hence cannot be listed as ParkingAvailableProperty."));
                }
            }
            return await Task.FromResult<List<ValidationModel>>(validationResults);
        }

        public async Task<List<ValidationModel>> ValidatePropertyViewingAsync(string loggedInUser, PropertyViewingModel model)
        {
            var validationResults = new List<ValidationModel>();

            if (loggedInUser == null)
            {
                validationResults.Add(new ValidationModel("Invalid LoggedIn user."));
            }
            var propertyListing = await this.propertyRepo.GetPropertyListingAsync(model.PropertyListingUID);
            if (propertyListing == null)
            {
                validationResults.Add(new ValidationModel("The given property listing doesn't exists."));
            }
            else
            {
                if (!propertyListing.IsActive)
                {
                    validationResults.Add(new ValidationModel("The given property listing is inactive."));
                }
                else
                {
                    var property = await this.propertyRepo.GetPropertyAsync(propertyListing.PropertyUID);
                    if (property == null)
                    {
                        validationResults.Add(new ValidationModel("The given property profile doesn't exists."));
                    }
                    else
                    {
                        var landLord = await this.landlordRepo.GetLandlordByProfileAsync(property.LandlordUID);
                        if (landLord == null)
                        {
                            validationResults.Add(new ValidationModel("The given landlord profile doesn't exists."));
                        }
                        else
                        {
                            if (!landLord.IsActive)
                            {
                                validationResults.Add(new ValidationModel("The given landlord profile is inactive."));
                            }
                            else
                            {
                                var user = await this.userRepo.GetUserByUIDAsync(landLord.UserUID);
                                if (user == null)
                                {
                                    validationResults.Add(new ValidationModel("The given landlord user doesn't exists."));
                                }
                                else
                                {
                                    if (
                                        (!string.Equals(user.Role.Name, RoleConstant.Admin) && !string.Equals(user.Role.Name, RoleConstant.Consultant)) &&
                                         !string.Equals(loggedInUser, user.UID)
                                        )
                                    {
                                        validationResults.Add(new ValidationModel("LoggedIn user doesnt match with landlord user given in model."));
                                    }
                                }
                            }

                        }
                    }
                }             

            }

            if (string.IsNullOrEmpty(model.TenantUID))
            {
                validationResults.Add(new ValidationModel("TenantUID is a mandatory field."));
            }
            else
            {
                var tenantProfile=await this.uow.TenantRepository.GetTenantAsync(model.TenantUID);
                if(tenantProfile == null)
                {
                    validationResults.Add(new ValidationModel("The given tenant profile doesn't exists."));
                }
                else
                {
                    if (!tenantProfile.IsActive)
                    {
                        validationResults.Add(new ValidationModel("The given tenant profile is inactive."));
                    }
                }
            }
            if (model.StartDateTime==null)
            {
                validationResults.Add(new ValidationModel("StartDate and time is a mandatory field."));
            }
            if (model.EndDateTime == null)
            {
                validationResults.Add(new ValidationModel("EndDate and time is a mandatory field."));
            }
            if (model.StartDateTime != null && model.EndDateTime!=null && model.StartDateTime<model.EndDateTime)
            {
                validationResults.Add(new ValidationModel("The given start and end date range is invalid."));
            }
            return await Task.FromResult<List<ValidationModel>>(validationResults);
        }

        public async Task<List<ValidationModel>> ValidatePropertyRentingAsync(string loggedInUser, PropertyRentingModel model)
        {
            var validationResults = new List<ValidationModel>();

            if (loggedInUser == null)
            {
                validationResults.Add(new ValidationModel("Invalid LoggedIn user."));
            }
            var propertyListing = await this.propertyRepo.GetPropertyListingAsync(model.PropertyListingUID);
            if (propertyListing == null)
            {
                validationResults.Add(new ValidationModel("The given property listing doesn't exists."));
            }
            else
            {
                if (!propertyListing.IsActive)
                {
                    validationResults.Add(new ValidationModel("The given property listing is inactive."));
                }
                else
                {
                    var property = await this.propertyRepo.GetPropertyAsync(propertyListing.PropertyUID);
                    if (property == null)
                    {
                        validationResults.Add(new ValidationModel("The given property profile doesn't exists."));
                    }
                    else
                    {
                        var landLord = await this.landlordRepo.GetLandlordByProfileAsync(property.LandlordUID);
                        if (landLord == null)
                        {
                            validationResults.Add(new ValidationModel("The given landlord profile doesn't exists."));
                        }
                        else
                        {
                            if (!landLord.IsActive)
                            {
                                validationResults.Add(new ValidationModel("The given landlord profile is inactive."));
                            }
                            else
                            {
                                var user = await this.userRepo.GetUserByUIDAsync(landLord.UserUID);
                                if (user == null)
                                {
                                    validationResults.Add(new ValidationModel("The given landlord user doesn't exists."));
                                }
                                else
                                {
                                    if (
                                        (!string.Equals(user.Role.Name, RoleConstant.Admin) && !string.Equals(user.Role.Name, RoleConstant.Consultant)) &&
                                         !string.Equals(loggedInUser, user.UID)
                                        )
                                    {
                                        validationResults.Add(new ValidationModel("LoggedIn user doesnt match with landlord user given in model."));
                                    }
                                }
                            }

                        }
                    }
                }

            }

            if (string.IsNullOrEmpty(model.TenantUID))
            {
                validationResults.Add(new ValidationModel("RentedUserUID is a mandatory field."));
            }
            else
            {
                var tenantProfile = await this.uow.TenantRepository.GetTenantAsync(model.TenantUID);
                if (tenantProfile == null)
                {
                    validationResults.Add(new ValidationModel("The given tenant profile doesn't exists."));
                }
                else
                {
                    if (!tenantProfile.IsActive)
                    {
                        validationResults.Add(new ValidationModel("The given tenant profile is inactive."));
                    }
                }
            }
            if (model.RentStartDate == null)
            {
                validationResults.Add(new ValidationModel("Rent StartDate and time is a mandatory field."));
            }
            if (model.RentEndDate == null)
            {
                validationResults.Add(new ValidationModel("Rent EndDate and time is a mandatory field."));
            }
            if (model.RentStartDate != null && model.RentEndDate != null && model.RentStartDate < model.RentEndDate)
            {
                validationResults.Add(new ValidationModel("The given start and end date range is invalid."));
            }
            return await Task.FromResult<List<ValidationModel>>(validationResults);
        }

        public async Task<List<ValidationModel>> ValidatePropertyImageAsync(string loggedInUser, PropertyImageModel model)
        {
            var validationResults = new List<ValidationModel>();

            if (loggedInUser == null)
            {
                validationResults.Add(new ValidationModel("Invalid LoggedIn user."));
            }
            var property=await this.propertyRepo.GetPropertyAsync(model.PropertyUID);
            if(property == null)
            {
                validationResults.Add(new ValidationModel("The given property profile doesn't exists."));
            }
            else
            {
                var landLord = await this.landlordRepo.GetLandlordByProfileAsync(property.LandlordUID);
                if (landLord == null)
                {
                    validationResults.Add(new ValidationModel("The given landlord profile doesn't exists."));
                }
                else
                {
                    var user = await this.userRepo.GetUserByUIDAsync(landLord.UserUID);
                    if (user == null)
                    {
                        validationResults.Add(new ValidationModel("The given landlord user doesn't exists."));
                    }
                    else
                    {
                        if (
                            (!string.Equals(user.Role.Name, RoleConstant.Admin) && !string.Equals(user.Role.Name, RoleConstant.Consultant)) &&
                             !string.Equals(loggedInUser, user.UID)
                            )
                        {
                            validationResults.Add(new ValidationModel("LoggedIn user doesnt match with landlord user given in model."));
                        }
                    }

                }
            }
            return await Task.FromResult<List<ValidationModel>>(validationResults);
        }

    }
}
