
namespace DataAccess.Interface
{
    public interface IStudentRepository
    {
        Task<Student> AddStudentAsync(Student student);
        Task<Student> UpdateStudentAsync(Student student);
        Task<bool> DeleteStudentAsync(Student student);
        Task<Student> GetStudentByCodeAsync(string code);
        Task<Student> GetStudentByIdAsync(int id);
        Task<Student> GetStudentByNameAsync(string name);
        Task<Student[]> GetAllStudentsAsync();
        
    }
}
