
namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        SSDbContext context = null;
        public UnitOfWork(SSDbContext context)
        {
            this.context = context;
        }

        public IStudentRepository StudentRepository => new StudentRepository(this.context);
        public IUniversityRepository UniversityRepository => new UniversityRepository(this.context);
        public IUserRepository UserRepository => new UserRepository(this.context);
        public ILandlordRepository LandlordRepository => new LandlordRepository(this.context);
        public IPropertyRepository PropertyRepository => new PropertyRepository(this.context);  
        public IImageFileRepository ImageFileRepository => new ImageFileRepository(this.context);   
        public IRolesRepository RolesRepository => new RolesRepository(this.context);
        public ICountryRepository CountryRepository => new CountryRepository(this.context);
        public ITenantRepository TenantRepository => new TenantRepository(this.context);

        public IItemRepository ItemRepository => new ItemRepository(this.context);

        public IItemTypeRepository ItemTypeRepository => new ItemTypeRepository(this.context);

        public IPropertyTypeRepository PropertyTypeRepository => new PropertyTypeRepository(this.context);

        public ITenancyTypeRepository TenancyTypeRepository => new TenancyTypeRepository(this.context);

        public ICurrencyRepository CurrencyRepository => new CurrencyRepository(this.context);

        public IFurnishTypeRepository FurnishTypeRepository => new FurnishTypeRepository(this.context);

        public void Dispose()
        {
            this.context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this.context.SaveChangesAsync();
        }
    }
}
