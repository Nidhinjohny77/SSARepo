

namespace DataAccess.Repository
{
    public class FurnishTypeRepository : IFurnishTypeRepository
    {
        private readonly SSDbContext context;

        public FurnishTypeRepository(SSDbContext context)
        {
            this.context = context;
        }

        public IQueryable<FurnishType> GetAllFurnishTypes()
        {
            return this.context.FurnishTypes.AsQueryable();
        }

        public async Task<FurnishType[]> GetAllFurnishTypesAsync()
        {
            return await this.context.FurnishTypes.ToArrayAsync();
        }
    }
}
