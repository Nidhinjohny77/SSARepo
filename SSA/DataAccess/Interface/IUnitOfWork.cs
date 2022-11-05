

namespace DataAccess.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        IStudentRepository StudentRepository { get; }
        IUniversityRepository UniversityRepository { get; } 
        IUserRepository UserRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
