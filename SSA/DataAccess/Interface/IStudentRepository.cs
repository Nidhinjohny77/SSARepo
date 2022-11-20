
namespace DataAccess.Interface
{
    public interface IStudentRepository
    {
        Task<bool> AddStudentAsync(Student student);
        Task<bool> UpdateStudentAsync(Student student);
        Task<bool> DeleteStudentAsync(Student student);
        Task<Student> GetStudentByCodeAsync(string code);
        Task<Student> GetStudentByProfileAsync(string profileUID);
        Task<Student> GetStudentProfileAsync(string userUID);
        IQueryable<Student> GetAllStudents();
    }
}
