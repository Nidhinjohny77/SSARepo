

namespace Business.Interface
{
    public interface IStudentManager
    {
        Task<Result<StudentProfileModel>> CreateStudentProfileAysnc(string loggedInUser, StudentProfileModel student);
        Task<Result<StudentProfileModel>> UpdateStudentProfileAsync(string loggedInUser, StudentProfileModel candidate);
        Task<Result<StudentProfileModel>> GetStudentProfileAsync(string loggedInUser);
        Task<Result<bool>> DeleteStudentProfileAsync(string loggedInUser);
    }
}
