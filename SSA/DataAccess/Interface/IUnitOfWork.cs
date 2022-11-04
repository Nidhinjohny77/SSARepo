

namespace DataAccess.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        IStudentRepository StudentRepository { get; }
        IUniversityRepository UniversityRepository { get; } 
        Task<int> SaveChangesAsync();
    }
}
