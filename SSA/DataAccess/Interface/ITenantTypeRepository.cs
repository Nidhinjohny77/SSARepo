

namespace DataAccess.Interface
{
    public interface ITenantTypeRepository
    {
        IQueryable<TenancyType> GetAllTenantTypes();

        Task<TenancyType[]> GetAllTenantTypesAsync();
    }
}
