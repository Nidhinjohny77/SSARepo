

namespace DataAccess.Interface
{
    public interface IFurnishTypeRepository
    {
        IQueryable<FurnishType> GetAllFurnishTypes();

        Task<FurnishType[]> GetAllFurnishTypesAsync();
    }
}
