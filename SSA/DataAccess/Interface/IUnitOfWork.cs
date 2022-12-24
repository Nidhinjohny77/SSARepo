

namespace DataAccess.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        IStudentRepository StudentRepository { get; }
        IUniversityRepository UniversityRepository { get; } 
        IUserRepository UserRepository { get; }
        IImageFileRepository ImageFileRepository { get; }
        ILandlordRepository LandlordRepository { get; }
        IPropertyRepository PropertyRepository { get; }
        IRolesRepository RolesRepository { get; }
        ICountryRepository CountryRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
