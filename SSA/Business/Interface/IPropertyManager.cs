

namespace Business.Interface
{
    public interface IPropertyManager
    {
        Task<Result<PropertyModel>> CreatePropertyAsync(string loggedInUser, PropertyModel property);
        Task<Result<PropertyModel>> UpdatePropertyAsync(string loggedInUser, PropertyModel property);
        Task<Result<List<PropertyModel>>> GetPropertiesByLandlordAsync(string loggedInUser, string landlordProfileUID);
        Task<Result<PropertyModel>> GetPropertyByUIDAsync(string loggedInUser, string propertyUID);
        Task<Result<bool>> DeletePropertyAsync(string loggedInUser, string propertyUID);

        Task<Result<PropertyAttributeModel>> CreatePropertyAttributeAsync(string loggedInUser, PropertyAttributeModel propertyAttribute);
        Task<Result<PropertyAttributeModel>> UpdatePropertyAttributeAsync(string loggedInUser, PropertyAttributeModel propertyAttribute);
        Task<Result<PropertyAttributeModel[]>> GetAllPropertyAttributesByPropertyAsync(string loggedInUser, string propertyUID);
        Task<Result<PropertyAttributeModel>> GetPropertyAttributeByUIDAsync(string loggedInUser, string propertyAttributeUID);
        Task<Result<PropertyAttributeModel>> GetPropertyAttributeByPropertyAsync(string loggedInUser, string propertyUID);
        Task<Result<bool>> DeletePropertyAttributeAsync(string loggedInUser, string propertyAttributeUID);

        Task<Result<PropertyImageModel>> CreatePropertyImageAsync(string loggedInUser, PropertyImageModel model);
        Task<Result<PropertyImageModel[]>> GetAllPropertyImagesAsync(string loggedInUser, string propertyUID);

        Task<Result<PropertyImageModel>> GetPropertyImageAsync(string loggedInUser, string propertyImageUID);
        Task<Result<bool>> DeleteAllPropertyImagesAsync(string loggedInUser, string propertyUID);
        Task<Result<bool>> DeletePropertyImageAsync(string loggedInUser, string propertyImageUID);

        Task<Result<PropertyListingModel>> CreatePropertyListingAsync(string loggedInUser, PropertyListingModel propertyListing);
        Task<Result<List<PropertyListingModel>>> GetAllPropertyListingsAsync(string loggedInUser, string landlordUID);
        Task<Result<List<PropertyDataModel>>> GetAllPropertyListingsByFilterAsync(string loggedInUser, PropertyListingFilterModel filter);
        Task<Result<PropertyListingModel>> GetPropertyListingByUIDAsync(string loggedInUser, string propertyListingUID);
        Task<Result<PropertyListingModel>> UpdatePropertyListing(string loggedInUser, PropertyListingModel propertyListing);
        Task<Result<bool>> DeletePropertyListingAsync(string loggedInUser, string propertyListingUID);

        Task<Result<PropertyListingAttributeModel>> CreatePropertyListingAttributeAsync(string loggedInUser, PropertyListingAttributeModel propertyListingAttribute);
        Task<Result<PropertyListingAttributeModel>> GetPropertyListingAttributeAsync(string loggedInUser, string propertyListingAttributeUID);
        Task<Result<PropertyListingAttributeModel>> GetPropertyListingAttributeByListingUIDAsync(string loggedInUser, string propertyListingUID);
        Task<Result<PropertyListingAttributeModel[]>> GetAllPropertyListingAttributesByListingUIDAsync(string loggedInUser, string propertyListingUID);
        Task<Result<PropertyListingAttributeModel>> UpdatePropertyListingAttributeAsync(string loggedInUser, PropertyListingAttributeModel propertyListingAttribute);
        Task<Result<bool>> DeletePropertyListingAttributeAsync(string loggedInUser, string propertyListingAttributeUID);

        Task<Result<PropertyViewingModel>> CreatePropertyViewing(string loggedInUser, PropertyViewingModel propertyViewingModel);
        Task<Result<PropertyViewingModel>> UpdatePropertyViewingAsync(string loggedInUser, PropertyViewingModel propertyViewingModel);
        Task<Result<List<PropertyViewingModel>>> GetAllPropertyViewingsByTenantAsync(string loggedInUser, string tenantUID);
        Task<Result<List<PropertyViewingModel>>> GetAllPropertyViewingsByLandlordAsync(string loggedInUser, string landlordUID);
        Task<Result<bool>> DeletePropertyViewing(string loggedInUser, string propertyViewingUID);

        Task<Result<PropertyRentingModel>> CreatePropertyRentingAsync(string loggedInUser, PropertyRentingModel propertyRentingModel);
        Task<Result<PropertyRentingModel>> UpdatePropertyRentingAsync(string loggedInUser, PropertyRentingModel propertyRentingModel);
        Task<Result<List<PropertyRentingModel>>> GetAllPropertyRentingsByLandlordAsync(string loggedInUser, string landlordProfileUID);
        Task<Result<List<PropertyRentingModel>>> GetAllPropertyRentingsByTenantAsync(string loggedInUser, string tenantUID);

        Task<Result<List<PropertyRentingModel>>> GetAllActivePropertyRentingsByLandlordAsync(string loggedInUser, string landlordProfileUID);
        Task<Result<List<PropertyRentingModel>>> GetAllActivePropertyRentingsByTenantAsync(string loggedInUser, string tenantUID);
        Task<Result<List<PropertyRentingModel>>> GetAllPropertyRentingByPropertyUIDAsync(string loggedInUser, string propertyUID);
        Task<Result<PropertyRentingModel>> GetActivePropertyRentingByPropertyUIDAsync(string loggedInUser, string propertyUID);
        Task<Result<bool>> DeletePropertyRentingAsync(string loggedInUser, string propertyRentingUID);
    }
}
