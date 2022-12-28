

namespace Business.Validators
{
    public class TenantValidator:ValidatorBase,ITenantValidator
    {
        private readonly ITenantRepository repo;

        public TenantValidator(IUnitOfWork uow):base(uow)
        {
            this.repo = this.uow.TenantRepository;
        }

        protected string GetUserUID(string tenantUID)
        {
            var tenant = this.uow.TenantRepository.GetTenantAsync(tenantUID).Result;

            return tenant == null ? null : tenant.UserUID;
        }

        protected bool IsPropertyTypeExists(int propertyTypeUID)
        {
            return this.uow.PropertyTypeRepository.GetAllPropertyTypes().Where(x=>x.UID == propertyTypeUID).Any();
        }

        protected bool IsFurnishmentTypeExists(int furnishmentTypeUID)
        {
            return this.uow.FurnishTypeRepository.GetAllFurnishTypes().Where(x => x.UID == furnishmentTypeUID).Any();
        }

        protected bool IsTenantTypeExists(int tenantTypeUID)
        {
            return this.uow.TenantTypeRepository.GetAllTenantTypes().Where(x => x.UID == tenantTypeUID).Any();
        }

        public async Task<List<ValidationModel>> ValidateTenantAsync(string loggedInUser, TenantModel tenant)
        {
            var validationResults = new List<ValidationModel>();
            if (string.IsNullOrEmpty(tenant.UserUID))
            {
                validationResults.Add(new ValidationModel("Tenant UserUID is a mandatory field."));
            }
            else
            {
                if (tenant.UserUID != loggedInUser)
                {
                    validationResults.Add(new ValidationModel("The current loggedIn user doesn't have permission to edit profile of another user."));
                }
            }

            if (string.IsNullOrEmpty(tenant.Address))
            {
                validationResults.Add(new ValidationModel("Address is a mandatory field."));
            }
            if (string.IsNullOrEmpty(tenant.DOB))
            {
                validationResults.Add(new ValidationModel("Date Of Birth(DOB) is a mandatory field."));
            }
            DateOnly dateOfBirth;
            bool isValidDOB = DateOnly.TryParse(tenant.DOB, out dateOfBirth);
            if (!isValidDOB)
            {
                validationResults.Add(new ValidationModel("DOB(Date Of Birth) is not in proper date format (dd/mm/yyyy)."));
            }
            else
            {
                var currentDate = DateTime.Now.Date;
                var birthDate = dateOfBirth.ToDateTime(TimeOnly.FromTimeSpan(TimeSpan.Zero)).Date;
                if (birthDate > currentDate)
                {
                    validationResults.Add(new ValidationModel("Future value for DOB(Date Of Birth) is not accepted."));
                }
                else
                {
                    var diffYears = ((currentDate - birthDate).TotalDays) / 365;
                    if (diffYears < 16)
                    {
                        validationResults.Add(new ValidationModel("The given tenant is not of legal age."));
                    }
                }
                
            }
            return await Task.FromResult<List<ValidationModel>>(validationResults);
        }

        public async Task<List<ValidationModel>> ValidateTenantPreferenceAsync(string loggedInUser, TenantPreferenceModel tenantPreference)
        {
            var validationResults = new List<ValidationModel>();
            if (string.IsNullOrEmpty(tenantPreference.TenantUID))
            {
                validationResults.Add(new ValidationModel("TenantUID is a mandatory field."));
            }
            else
            {
                var modelSpecificUserUID = GetUserUID(tenantPreference.TenantUID);
                if (GetRole(modelSpecificUserUID) != RoleConstant.Admin && modelSpecificUserUID != loggedInUser)
                {
                    validationResults.Add(new ValidationModel("The current loggedIn user doesn't have permission to edit preferences of another user."));
                }
            }
            if (!IsPropertyTypeExists(tenantPreference.PropertyTypeUID))
            {
                validationResults.Add(new ValidationModel("The given PropertyTypeUID is not valid."));
            }
            if (!IsFurnishmentTypeExists(tenantPreference.FurnishTypeUID))
            {
                validationResults.Add(new ValidationModel("The given FurnishTypeUID is not valid."));
            }
            if (tenantPreference.PreferedTenancyTypeUID.HasValue)
            {
                if (!IsTenantTypeExists(tenantPreference.PreferedTenancyTypeUID.Value))
                {
                    validationResults.Add(new ValidationModel("The given PreferedTenancyTypeUID is not valid."));
                }
            }

            return await Task.FromResult<List<ValidationModel>>(validationResults);
        }
    }
}
