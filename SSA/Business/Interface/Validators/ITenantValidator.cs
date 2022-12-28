
namespace Business.Interface.Validators
{
    public interface ITenantValidator
    {
        Task<List<ValidationModel>> ValidateTenantAsync(string loggedInUser, TenantModel tenant);
        Task<List<ValidationModel>> ValidateTenantPreferenceAsync(string loggedInUser, TenantPreferenceModel tenantPreference);
    }
}
