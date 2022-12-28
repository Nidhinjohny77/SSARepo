

namespace Business.Interface.Validators
{
    public interface IPropertyValidator
    {
        Task<List<ValidationModel>> ValidatePropertyAsync(string loggedInUser, PropertyModel model);
        Task<List<ValidationModel>> ValidatePropertyListingAsync(string loggedInUser, PropertyListingModel model);
        Task<List<ValidationModel>> ValidatePropertyViewingAsync(string loggedInUser, PropertyViewingModel model);

        Task<List<ValidationModel>> ValidatePropertyRentingAsync(string loggedInUser, PropertyRentingModel model);

        Task<List<ValidationModel>> ValidatePropertyImageAsync(string loggedInUser, PropertyImageModel model);


    }
}
