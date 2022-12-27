

namespace DataAccess.Interface
{
    public interface IItemTypeRepository
    {
        IQueryable<ItemType> GetAllItemTypes();

        Task<ItemType[]> GetAllItemTypesAsync();
    }
}
