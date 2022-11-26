

namespace Business.Interface.Validators
{
    public interface IStudentValidator
    {
        Task<List<ValidationResult>> ValidateAsync(string loggedInUser,StudentModel student);
    }
}
