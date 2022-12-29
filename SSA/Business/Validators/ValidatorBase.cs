

namespace Business.Validators
{
    public abstract class ValidatorBase
    {
        protected readonly IUnitOfWork uow;

        protected ValidatorBase(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        protected string GetRole(string loggedInUser)
        {
            var user=this.uow.UserRepository.GetUserByUIDAsync(loggedInUser).Result;
            var role=this.uow.RolesRepository.GetAllRoles().Where(r=>r.UID==user.RoleUID).FirstOrDefault();
            return role==null?null:role.Name;
        }

        protected bool IsValidDate(string dateStr,out DateOnly date)
        {
            bool isValid = DateOnly.TryParse(dateStr, out date);
            return isValid;
        }

        protected bool IsFutureDateOfBirth(DateOnly date)
        {
            var currentDate = DateTime.Now.Date;
            var birthDate = date.ToDateTime(TimeOnly.FromTimeSpan(TimeSpan.Zero)).Date;
            return (birthDate > currentDate);
        }

        protected bool IsCountryValid(int countryUID)
        {
            return this.uow.CountryRepository.GetAllCountries().Where(x => x.UID == countryUID).Any();
        }
    }
}
