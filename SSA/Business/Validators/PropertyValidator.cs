

namespace Business.Validators
{
    public class PropertyValidator : IPropertyValidator
    {
        private readonly IUnitOfWork uow;
        private readonly IUserRepository userRepo;
        private readonly ILandlordRepository landlordRepo;
        private readonly IPropertyRepository propertyRepo;

        public PropertyValidator(IUnitOfWork uow)
        {
            this.uow = uow;
            this.userRepo = this.uow.UserRepository;
            this.landlordRepo = this.uow.LandlordRepository;
            this.propertyRepo = this.uow.PropertyRepository;
        }
        public async Task<List<ValidationModel>> ValidatePropertyAsync(string loggedInUser, PropertyModel model)
        {
            var validationResults = new List<ValidationModel>();

            if (loggedInUser == null)
            {
                validationResults.Add(new ValidationModel("Invalid LoggedIn user."));
            }
            var landLord = await this.landlordRepo.GetLandlordByProfileAsync(model.LandlordProfileUID);
            if (landLord == null)
            {
                validationResults.Add(new ValidationModel("The given landlord profile doesn't exists."));
            }
            else 
            {
                var user=await this.userRepo.GetUserAsync(landLord.UserUID);
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
            if (string.IsNullOrEmpty(model.Name))
            {
                validationResults.Add(new ValidationModel("Name is a mandatory field."));
            }
            if (string.IsNullOrEmpty(model.LandlordProfileUID))
            {
                validationResults.Add(new ValidationModel("Lanlord profile UID is a mandatory field."));
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
            if(property == null)
            {
                validationResults.Add(new ValidationModel("The given property profile doesn't exists."));
            }
            else
            {
                var landLord = await this.landlordRepo.GetLandlordByProfileAsync(property.LandlordProfileUID);
                if (landLord == null)
                {
                    validationResults.Add(new ValidationModel("The given landlord profile doesn't exists."));
                }
                else
                {
                    var user = await this.userRepo.GetUserAsync(landLord.UserUID);
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

            if (!Enum.IsDefined(typeof(ListingStatus), model.ListingStatus))
            {
                validationResults.Add(new ValidationModel("ListingStatus contains invalid value."));
            }
            if (!Enum.IsDefined(typeof(Agent), model.Listedby))
            {
                validationResults.Add(new ValidationModel("ListedBy contains invalid value."));
            }
            if (model.ListingAmount<0)
            {
                validationResults.Add(new ValidationModel("ListingAmount should have a valid amount(>0)."));
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
                        var landLord = await this.landlordRepo.GetLandlordByProfileAsync(property.LandlordProfileUID);
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
                                var user = await this.userRepo.GetUserAsync(landLord.UserUID);
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
                        var landLord = await this.landlordRepo.GetLandlordByProfileAsync(property.LandlordProfileUID);
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
                                var user = await this.userRepo.GetUserAsync(landLord.UserUID);
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
                var landLord = await this.landlordRepo.GetLandlordByProfileAsync(property.LandlordProfileUID);
                if (landLord == null)
                {
                    validationResults.Add(new ValidationModel("The given landlord profile doesn't exists."));
                }
                else
                {
                    var user = await this.userRepo.GetUserAsync(landLord.UserUID);
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
