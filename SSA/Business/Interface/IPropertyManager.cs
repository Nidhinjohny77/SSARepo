

namespace Business.Interface
{
    public interface IPropertyManager
    {
        Task<Result<PropertyModel>> CreatePropertyAsync(string userUID, PropertyModel property);
        Task<Result<PropertyModel>> UpdatePropertyAsync(string userUID, PropertyModel property);
        Task<Result<List<PropertyModel>>> GetPropertiesByLandlordAsync(string userUID, string landlordProfileUID);
        Task<Result<PropertyModel>> GetPropertyByUIDAsync(string userUID, string propertyUID);
        Task<Result<bool>> DeletePropertyAsync(string userUID, string propertyUID);

        Task<Result<bool>> UploadPropertyImageAsync(string userUID, PropertyImageModel model);
        Task<Result<PropertyImageModel[]>> GetAllPropertyImagesAsync(string userUID, string propertyUID);
        Task<Result<bool>> DeleteAllPropertyImagesAsync(string userUID, string propertyUID);
        Task<Result<bool>> DeletePropertyImageAsync(string userUID, string propertyImageUID);

        Task<Result<PropertyListingModel>> CreatePropertyListingAsync(string userUID, PropertyListingModel propertyListing);
        Task<Result<List<PropertyListingModel>>> GetAllPropertyListingsAsync(string userUID,string landlordProfileUID);
        Task<Result<List<PropertyListingModel>>> GetAllPropertyListingsByFilterAsync(string userUID, PropertyListingFilterModel filter);
        Task<Result<PropertyListingModel>> GetPropertyListingByUIDAsync(string userUID, string propertyListingUID);
        Task<Result<PropertyListingModel>> UpdatePropertyListing(string userUID, PropertyListingModel propertyListing);
        Task<Result<bool>> DeletePropertyListingAsync(string userUID, string propertyListingUID);

        Task<Result<PropertyViewingModel>> CreatePropertyViewing(string userUID, PropertyViewingModel propertyViewingModel);
        Task<Result<PropertyViewingModel>> UpdatePropertyViewingAsync(string userUID, PropertyViewingModel propertyViewingModel);
        Task<Result<List<PropertyViewingModel>>> GetAllPropertyViewingsByStudentAsync(string userUID, string studentProfileUID);
        Task<Result<List<PropertyViewingModel>>> GetAllPropertyViewingsByLandlordAsync(string userUID, string landlordUID);
        Task<Result<bool>> DeletePropertyViewing(string userUID, string propertyViewingUID);

        Task<Result<PropertyRentingModel>> CreatePropertyRentingAsync(string userUID, PropertyRentingModel propertyRentingModel);
        Task<Result<PropertyRentingModel>> UpdatePropertyRentingAsync(string userUID, PropertyRentingModel propertyRentingModel);
        Task<Result<List<PropertyRentingModel>>> GetAllPropertyRentingsByLandlordAsync(string userUID, string landlordProfileUID);
        Task<Result<List<PropertyRentingModel>>> GetAllPropertyRentingsByStudentAsync(string userUID, string studentProfileUID);

        Task<Result<List<PropertyRentingModel>>> GetAllActivePropertyRentingsByLandlordAsync(string userUID, string landlordProfileUID);
        Task<Result<List<PropertyRentingModel>>> GetAllActivePropertyRentingsByStudentAsync(string userUID, string studentProfileUID);
        Task<Result<List<PropertyRentingModel>>> GetAllPropertyRentingByPropertyUIDAsync(string userUID, string propertyUID);
        Task<Result<PropertyRentingModel>> GetActivePropertyRentingByPropertyUIDAsync(string userUID, string propertyUID);
        Task<Result<bool>> DeletePropertyRentingAsync(string userUID, string propertyRentingUID);
    }
}
