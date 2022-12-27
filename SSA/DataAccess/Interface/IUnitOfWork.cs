﻿

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
        ITenantRepository TenantRepository { get; }
        IItemRepository ItemRepository { get; }
        IItemTypeRepository ItemTypeRepository { get; } 
        IPropertyTypeRepository PropertyTypeRepository { get; } 
        ITenantTypeRepository TenantTypeRepository { get; }
        ICurrencyRepository CurrencyRepository { get; }
        IFurnishTypeRepository FurnishTypeRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
