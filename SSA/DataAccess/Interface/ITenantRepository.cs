
namespace DataAccess.Interface
{
    public interface ITenantRepository
    {
        Task<Tenant> GetTenantAsync(string tenantUID);
        Task<Tenant> GetTenantByUserUIDAsync(string userUID);
        IQueryable<Tenant> GetAllTenants();
        Task<bool> CreateTenantAsync(Tenant tenant);
        Task<bool> UpdateTenantAsync(Tenant tenant);
        Task<bool> DeleteTenantAsync(Tenant tenant);

        Task<TenantPreference> GetTenantPreferenceAsync(string tenantUID);
        Task<TenantPreference> GetTenantPreferenceByUIDAsync(string UID);
        IQueryable<TenantPreference> GetAllTenantPreferences();
        Task<bool> CreateTenantPreferenceAsync(TenantPreference tenantPreference);
        Task<bool> UpdateTenantPreferenceAsync(TenantPreference tenantPreference);
        Task<bool> DeleteTenantPreferenceAsync(TenantPreference tenantPreference);
    }
}
