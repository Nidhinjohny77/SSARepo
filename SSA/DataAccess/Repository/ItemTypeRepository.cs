

namespace DataAccess.Repository
{
    public class ItemTypeRepository : IItemTypeRepository
    {
        private readonly SSDbContext context;

        public ItemTypeRepository(SSDbContext context)
        {
            this.context = context;
        }

        public IQueryable<ItemType> GetAllItemTypes()
        {
            return this.context.ItemTypes.AsQueryable();
        }

        public async Task<ItemType[]> GetAllItemTypesAsync()
        {
            return await this.context.ItemTypes.ToArrayAsync();  
        }
    }
}
