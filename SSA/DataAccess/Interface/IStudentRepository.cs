
namespace DataAccess.Interface
{
    public interface IStudentRepository
    {
        Task<bool> AddStudentAsync(StudentProfile student);
        Task<bool> UpdateStudentAsync(StudentProfile student);
        Task<bool> DeleteStudentAsync(StudentProfile student);
        Task<StudentProfile> GetStudentByCodeAsync(string securityCode);
        Task<StudentProfile> GetStudentByProfileAsync(string profileUID);
        Task<StudentProfile> GetStudentProfileAsync(string tenantUID);
        IQueryable<StudentProfile> GetAllStudents();
    }
}
