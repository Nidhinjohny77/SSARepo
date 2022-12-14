

namespace Business.Interface
{
    public interface IPropertyManager
    {
        Task<Result<PropertyModel>> CreatePropertyAsync(string loggedInUser, PropertyModel property);
        Task<Result<PropertyModel>> UpdatePropertyAsync(string loggedInUser, PropertyModel property);
        Task<Result<List<PropertyModel>>> GetPropertiesByLandlordAsync(string loggedInUser, string landlordProfileUID);
        Task<Result<PropertyModel>> GetPropertyByUIDAsync(string loggedInUser, string propertyUID);
        Task<Result<bool>> DeletePropertyAsync(string loggedInUser, string propertyUID);

        Task<Result<bool>> CreatePropertyImageAsync(string loggedInUser, PropertyImageModel model);
        Task<Result<PropertyImageModel[]>> GetAllPropertyImagesAsync(string loggedInUser, string propertyUID);
        Task<Result<bool>> DeleteAllPropertyImagesAsync(string loggedInUser, string propertyUID);
        Task<Result<bool>> DeletePropertyImageAsync(string loggedInUser, string propertyImageUID);

        Task<Result<PropertyListingModel>> CreatePropertyListingAsync(string loggedInUser, PropertyListingModel propertyListing);
        Task<Result<List<PropertyListingModel>>> GetAllPropertyListingsAsync(string loggedInUser, string landlordProfileUID);
        Task<Result<List<PropertyListingModel>>> GetAllPropertyListingsByFilterAsync(string loggedInUser, PropertyListingFilterModel filter);
        Task<Result<PropertyListingModel>> GetPropertyListingByUIDAsync(string loggedInUser, string propertyListingUID);
        Task<Result<PropertyListingModel>> UpdatePropertyListing(string loggedInUser, PropertyListingModel propertyListing);
        Task<Result<bool>> DeletePropertyListingAsync(string loggedInUser, string propertyListingUID);

        Task<Result<PropertyViewingModel>> CreatePropertyViewing(string loggedInUser, PropertyViewingModel propertyViewingModel);
        Task<Result<PropertyViewingModel>> UpdatePropertyViewingAsync(string loggedInUser, PropertyViewingModel propertyViewingModel);
        Task<Result<List<PropertyViewingModel>>> GetAllPropertyViewingsByStudentAsync(string loggedInUser, string studentProfileUID);
        Task<Result<List<PropertyViewingModel>>> GetAllPropertyViewingsByLandlordAsync(string loggedInUser, string landlordUID);
        Task<Result<bool>> DeletePropertyViewing(string loggedInUser, string propertyViewingUID);

        Task<Result<PropertyRentingModel>> CreatePropertyRentingAsync(string loggedInUser, PropertyRentingModel propertyRentingModel);
        Task<Result<PropertyRentingModel>> UpdatePropertyRentingAsync(string loggedInUser, PropertyRentingModel propertyRentingModel);
        Task<Result<List<PropertyRentingModel>>> GetAllPropertyRentingsByLandlordAsync(string loggedInUser, string landlordProfileUID);
        Task<Result<List<PropertyRentingModel>>> GetAllPropertyRentingsByStudentAsync(string loggedInUser, string studentProfileUID);

        Task<Result<List<PropertyRentingModel>>> GetAllActivePropertyRentingsByLandlordAsync(string loggedInUser, string landlordProfileUID);
        Task<Result<List<PropertyRentingModel>>> GetAllActivePropertyRentingsByStudentAsync(string loggedInUser, string studentProfileUID);
        Task<Result<List<PropertyRentingModel>>> GetAllPropertyRentingByPropertyUIDAsync(string loggedInUser, string propertyUID);
        Task<Result<PropertyRentingModel>> GetActivePropertyRentingByPropertyUIDAsync(string loggedInUser, string propertyUID);
        Task<Result<bool>> DeletePropertyRentingAsync(string loggedInUser, string propertyRentingUID);
    }
}
