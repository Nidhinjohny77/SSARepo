

namespace DataAccess.Repository
{
    public class TenancyTypeRepository : ITenancyTypeRepository
    {
        private readonly SSDbContext context;

        public TenancyTypeRepository(SSDbContext context)
        {
            this.context = context;
        }

        public IQueryable<TenancyType> GetAllTenancyTypes()
        {
            return this.context.TenantTypes.AsQueryable();
        }

        public async Task<TenancyType[]> GetAllTenancyTypesAsync()
        {
            return await this.context.TenantTypes.ToArrayAsync();
        }
    }
}
