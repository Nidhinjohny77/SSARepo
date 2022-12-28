

namespace Business.Interface.Validators
{
    public interface IStudentValidator
    {
        Task<List<ValidationModel>> ValidateAsync(string loggedInUser,StudentProfileModel student);
    }
}
