
namespace Business.Interface.Validators
{
    public interface ITenantValidator
    {
        Task<List<ValidationResult>> ValidateTenantAsync(string loggedInUser, TenantModel tenant);
        Task<List<ValidationResult>> ValidateTenantPreferenceAsync(string loggedInUser, TenantPreferenceModel tenantPreference);
    }
}
