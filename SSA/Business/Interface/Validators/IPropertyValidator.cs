

namespace Business.Interface.Validators
{
    public interface IPropertyValidator
    {
        Task<List<ValidationResult>> ValidatePropertyAsync(string loggedInUser, PropertyModel model);
        Task<List<ValidationResult>> ValidatePropertyListingAsync(string loggedInUser, PropertyListingModel model);
        Task<List<ValidationResult>> ValidatePropertyViewingAsync(string loggedInUser, PropertyViewingModel model);

        Task<List<ValidationResult>> ValidatePropertyRentingAsync(string loggedInUser, PropertyRentingModel model);


    }
}
