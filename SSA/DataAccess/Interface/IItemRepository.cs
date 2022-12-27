

namespace DataAccess.Interface
{
    public interface IItemRepository
    {
        IQueryable<Item> GetAllItems();

        Task<Item[]> GetAllItemsAsync();
    }
}
