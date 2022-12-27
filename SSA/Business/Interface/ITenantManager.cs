
namespace Business.Interface
{
    public interface ITenantManager
    {
        Task<Result<TenantModel>> CreateTenantProfileAysnc(string loggedInUser, TenantModel tenant);
        Task<Result<TenantModel>> UpdateTenantProfileAsync(string loggedInUser, TenantModel tenant);
        Task<Result<TenantModel>> GetTenantProfileAsync(string loggedInUser);
        Task<Result<bool>> DeleteTenantProfileAsync(string loggedInUser);

        Task<Result<TenantPreferenceModel>> CreateTenantPreferencesAysnc(string loggedInUser, TenantPreferenceModel tenantPreference);

        Task<Result<TenantPreferenceModel>> UpdateTenantPreferencesAsync(string loggedInUser, TenantPreferenceModel tenantPreference);
        Task<Result<TenantPreferenceModel>> GetTenantPreferencesAsync(string loggedInUser,string tenantUID);
        Task<Result<bool>> DeleteTenantPreferencesAsync(string loggedInUser,string tenantPreferenceUID);
    }
}
