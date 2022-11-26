

namespace Business.Interface
{
    public interface IStudentManager
    {
        Task<Result<StudentModel>> CreateStudentProfileAysnc(string userUID, StudentModel student);
        Task<Result<StudentModel>> UpdateStudentProfileAsync(string userUID, StudentModel candidate);
        Task<Result<StudentModel>> GetStudentProfileAsync(string userUID);
        Task<Result<bool>> DeleteStudentProfileAsync(string userUID);
    }
}
