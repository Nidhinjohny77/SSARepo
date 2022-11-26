

namespace Business.Interface
{
    public interface IPropertyManager
    {
        Task<Result<PropertyModel>> CreatePropertyAsync(PropertyModel property);
        Task<Result<PropertyModel>> UpdatePropertyAsync(PropertyModel property);
        Task<Result<PropertyModel>> GetPropertyByLandlordAsync(string landlordProfileUID);
        Task<Result<PropertyModel>> GetPropertyByUIDAsync(string propertyUID);
        Task<Result<bool>> DeletePropertyAsync(string propertyUID);

        Task<Result<bool>> UploadPropertyImageAsync(PropertyImageModel model);
        Task<Result<PropertyImageModel>> GetAllPropertyImagesAsync(string propertyUID);
        Task<Result<bool>> DeleteAllPropertyImagesAsync(string propertyUID);
        Task<Result<bool>> DeletePropertyImageAsync(string propertyImageUID);

        Task<Result<PropertyListingModel>> CreatePropertyListingAsync(PropertyListingModel propertyListing);
        Task<Result<List<PropertyListingModel>>> GetAllPropertyListingsAsync();
        Task<Result<List<PropertyListingModel>>> GetAllPropertyListingsByFilterAsync(PropertyListingFilterModel filter);
        Task<Result<PropertyListingModel>> GetPropertyListingByUIDAsync(string propertyListingUID);
        Task<Result<PropertyListingModel>> UpdatePropertyListing(PropertyListingModel propertyListing);
        Task<Result<bool>> DeletePropertyListingAsync(string propertyListingUID);

        Task<Result<PropertyViewingModel>> CreatePropertyViewing(PropertyViewingModel propertyViewingModel);
        Task<Result<PropertyViewingModel>> UpdatePropertyViewingAsync(PropertyViewingModel propertyViewingModel);
        Task<Result<List<PropertyViewingModel>>> GetAllPropertyViewingsByStudentAsync(string studentUID);
        Task<Result<List<PropertyViewingModel>>> GetAllPropertyViewingsByLandlordAsync(string landlordUID);
        Task<Result<bool>> DeletePropertyViewing(string propertyViewingUID);
    }
}
