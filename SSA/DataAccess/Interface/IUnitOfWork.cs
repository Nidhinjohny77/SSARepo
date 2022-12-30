

namespace DataAccess.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        IStudentRepository StudentRepository { get; }
        IUniversityRepository UniversityRepository { get; } 
        IUserRepository UserRepository { get; }
        ILandlordRepository LandlordRepository { get; }
        IPropertyRepository PropertyRepository { get; }
        IRolesRepository RolesRepository { get; }
        ICountryRepository CountryRepository { get; }
        ITenantRepository TenantRepository { get; }
        IItemRepository ItemRepository { get; }
        IItemTypeRepository ItemTypeRepository { get; } 
        IPropertyTypeRepository PropertyTypeRepository { get; } 
        ITenancyTypeRepository TenancyTypeRepository { get; }
        ICurrencyRepository CurrencyRepository { get; }
        IFurnishTypeRepository FurnishTypeRepository { get; }
        IFileTypeRepository FileTypeRepository { get; }
        IImageTypeRepository ImageTypeRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
