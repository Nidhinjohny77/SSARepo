
namespace Business.Validators
{
    public class UserValidator : IUserValidator
    {

        public UserValidator()
        {
        }
        public async Task<List<ValidationResult>> ValidateAsync(string loggedInUser, UserModel user)
        {
            var validationResults = new List<ValidationResult>();
            if(loggedInUser == null)
            {
                validationResults.Add(new ValidationResult("Invalid LoggedIn user.LoggedIn user cannot be null."));
            }
            if (loggedInUser != user.UID)
            {
                validationResults.Add(new ValidationResult("Invalid LoggedIn user.LoggedIn user doesnt match with userUID in given user model."));
            }
            if (string.IsNullOrEmpty(user.UserName))
            {
                validationResults.Add(new ValidationResult("Username is mandatory"));
            }
            if (-1 == GetUserType(user.Role))
            {
                validationResults.Add(new ValidationResult("Invalid role."));
            }
            if (string.IsNullOrEmpty(user.Password))
            {
                validationResults.Add(new ValidationResult("Password is mandatory"));
            }
            if (string.IsNullOrEmpty(user.Email))
            {
                validationResults.Add(new ValidationResult("Email is mandatory"));
            }
            if (string.IsNullOrEmpty(user.FirstName))
            {
                validationResults.Add(new ValidationResult("FirstName is mandatory"));
            }
            return await Task.FromResult<List<ValidationResult>>( validationResults);
        }

        private int GetUserType(RoleModel role)
        {
            if (string.Equals(role.Name, RoleConstant.Admin))
            {
                return (int)UserType.Admin;
            }
            if (string.Equals(role.Name, RoleConstant.Consultant))
            {
                return (int)UserType.Consultant;
            }
            if (string.Equals(role.Name, RoleConstant.University))
            {
                return (int)UserType.University;
            }
            if (string.Equals(role.Name, RoleConstant.Student))
            {
                return (int)UserType.Student;
            }
            if (string.Equals(role.Name, RoleConstant.Landlord))
            {
                return (int)UserType.Landlord;
            }
            return -1;
        }
    }
}
