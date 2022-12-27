

namespace DataAccess.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly SSDbContext context;

        public ItemRepository(SSDbContext context)
        {
            this.context = context;
        }
        public IQueryable<Item> GetAllItems()
        {
            return this.context.Items.AsQueryable();
        }

        public async Task<Item[]> GetAllItemsAsync()
        {
            return await this.context.Items.ToArrayAsync();
        }
    }
}
