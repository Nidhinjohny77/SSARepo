
namespace Business.Validators
{
    public class LandlordValidator : ILandlordValidator
    {
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
            if (string.IsNullOrEmpty(model.DOB))
            {
                validationResults.Add(new ValidationModel("Date of birth is a mandatory field."));
            }
            if (string.IsNullOrEmpty(model.PhoneNumber))
            {
                validationResults.Add(new ValidationModel("Phone Number is a mandatory field."));
            }
            if (string.IsNullOrEmpty(model.CountryCode))
            {
                validationResults.Add(new ValidationModel("CountryCode is a mandatory field."));
            }
            return await Task.FromResult<List<ValidationModel>>(validationResults);
        }
    }
}
