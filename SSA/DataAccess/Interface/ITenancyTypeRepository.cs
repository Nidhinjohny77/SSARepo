

namespace DataAccess.Interface
{
    public interface ITenancyTypeRepository
    {
        IQueryable<TenancyType> GetAllTenancyTypes();

        Task<TenancyType[]> GetAllTenancyTypesAsync();
    }
}
