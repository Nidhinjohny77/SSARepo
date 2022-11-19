
namespace DataAccess.Interface
{
    public interface IStudentRepository
    {
        Task<Student> AddStudentAsync(Student student);
        Task<Student> UpdateStudentAsync(Student student);
        Task<bool> DeleteStudentAsync(Student student);
        Task<Student> GetStudentByCodeAsync(string code);
        Task<Student> GetStudentByIdAsync(string uid);
        Task<Student> GetStudentByNameAsync(string name);
        IQueryable<Student> GetAllStudents();
    }
}
