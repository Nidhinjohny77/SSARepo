
namespace Business.Validators
{
    public class LandlordValidator : ILandlordValidator
    {
        public async Task<List<ValidationResult>> ValidateAsync(string loggedInUser, LandlordModel model)
        {
            var validationResults=new List<ValidationResult>();

            if (loggedInUser == null)
            {
                validationResults.Add(new ValidationResult("Invalid LoggedIn user."));
            }
            if (loggedInUser != model.UserUID)
            {
                validationResults.Add(new ValidationResult("LoggedIn user doesnt match with userUID given in user model."));
            }
            if (string.IsNullOrEmpty(model.Address))
            {
                validationResults.Add(new ValidationResult("Address is a mandatory field."));
            }
            if (string.IsNullOrEmpty(model.DOB))
            {
                validationResults.Add(new ValidationResult("Date of birth is a mandatory field."));
            }
            if (string.IsNullOrEmpty(model.PhoneNumber))
            {
                validationResults.Add(new ValidationResult("Phone Number is a mandatory field."));
            }
            if (string.IsNullOrEmpty(model.CountryCode))
            {
                validationResults.Add(new ValidationResult("CountryCode is a mandatory field."));
            }
            return await Task.FromResult<List<ValidationResult>>(validationResults);
        }
    }
}
