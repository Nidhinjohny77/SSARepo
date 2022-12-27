

namespace DataAccess.Repository
{
    public class TenantTypeRepository : ITenantTypeRepository
    {
        private readonly SSDbContext context;

        public TenantTypeRepository(SSDbContext context)
        {
            this.context = context;
        }

        public IQueryable<TenancyType> GetAllTenantTypes()
        {
            return this.context.TenantTypes.AsQueryable();
        }

        public async Task<TenancyType[]> GetAllTenantTypesAsync()
        {
            return await this.context.TenantTypes.ToArrayAsync();
        }
    }
}
