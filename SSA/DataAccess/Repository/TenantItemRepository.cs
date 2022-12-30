

namespace DataAccess.Repository
{
    public class TenantItemRepository:ITenantItemRepository
    {
        private readonly SSDbContext context;

        public TenantItemRepository(SSDbContext context)
        {
            this.context = context;
        }
    }
}
