

namespace Business.Interface
{
    public interface IStudentManager
    {
        Task<Result<StudentModel>> CreateStudentProfileAysnc(string loggedInUser, StudentModel student);
        Task<Result<StudentModel>> UpdateStudentProfileAsync(string loggedInUser, StudentModel candidate);
        Task<Result<StudentModel>> GetStudentProfileAsync(string loggedInUser);
        Task<Result<bool>> DeleteStudentProfileAsync(string loggedInUser);
    }
}
