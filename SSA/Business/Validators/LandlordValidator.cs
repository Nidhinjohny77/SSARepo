
namespace Business.Validators
{
    public class LandlordValidator :ValidatorBase, ILandlordValidator
    {
        private readonly IUnitOfWork uow;

        public LandlordValidator(IUnitOfWork uow):base(uow)
        {
            this.uow = uow;
        }
        public async Task<List<ValidationModel>> ValidateAsync(string loggedInUser, LandlordModel model)
        {
            var validationResults=new List<ValidationModel>();

            if (loggedInUser == null)
            {
                validationResults.Add(new ValidationModel("Invalid LoggedIn user."));
            }
            if (loggedInUser != model.UserUID)
            {
                validationResults.Add(new ValidationModel("LoggedIn user doesnt match with userUID given in user model."));
            }
            if (string.IsNullOrEmpty(model.Address))
            {
                validationResults.Add(new ValidationModel("Address is a mandatory field."));
            }
            DateOnly dob;
            if (!IsValidDate(model.DOB,out dob))
            {
                validationResults.Add(new ValidationModel("DOB is not in correct format(dd/MM/YYYY)."));
            }
            else
            {
                if (IsFutureDateOfBirth(dob))
                {
                    validationResults.Add(new ValidationModel("DOB cannot be a value in future."));
                }
            }
            if (string.IsNullOrEmpty(model.PhoneNumber))
            {
                validationResults.Add(new ValidationModel("Phone Number is a mandatory field."));
            }

            if (!IsCountryValid(model.CountryUID))
            {
                validationResults.Add(new ValidationModel("The given CountryUID is not a valid value."));
            }
            return await Task.FromResult<List<ValidationModel>>(validationResults);
        }
    }
}
