
namespace DataAccess.Interface
{
    public interface IPropertyRepository
    {
        Task<bool> AddPropertyAsync(Property property);
        Task<bool> DeletePropertyAsync(Property property);
        Task<bool>UpdatePropertyAsync(Property property);
        Task<Property> GetPropertyAsync(string propertyUID);
        IQueryable<Property> GetAllProperties();

        Task<bool> AddPropertyImageAsync(PropertyImage image);
        Task<bool> UpdatePropertyImageAsync(PropertyImage image);
        Task<bool> DeletePropertyImageAsync(PropertyImage image);
        Task<PropertyImage> GetPropertyImageAsync(string propertyImageUID);
        IQueryable<PropertyImage> GetAllPropertyImages();

        Task<bool> AddPropertyListingAsync(PropertyListing listing);
        Task<bool> DeletePropertyListingAsync(PropertyListing listing);
        Task<bool> UpdatePropertyListingAsync(PropertyListing listing);
        Task<PropertyListing> GetPropertyListingAsync(string listingUID);
        IQueryable<PropertyListing> GetAllPropertyListings();

        Task<bool> AddPropertyViewingAsync(PropertyViewing viewing);
        Task<bool> DeletePropertyViewingAsync(PropertyViewing viewing);
        Task<bool> UpdatePropertyViewingAsync(PropertyViewing viewing);
        Task<PropertyViewing> GetPropertyViewingAsync(string viewingUID);
        IQueryable<PropertyViewing> GetAllPropertyViewings();

        Task<bool> AddPropertyRentingAsync(PropertyRenting renting);
        Task<bool> DeletePropertyRentingAsync(PropertyRenting renting);
        Task<bool> UpdatePropertyRentingAsync(PropertyRenting renting);
        Task<PropertyRenting> GetPropertyRentingAsync(string rentingUID);
        IQueryable<PropertyRenting> GetAllPropertyRentings();

        Task<bool> AddPropertyReviewsAsync(PropertyReview review);
        Task<bool> DeletePropertyReviewAsync(PropertyReview review);
        IQueryable<PropertyReview> GetAllPropertyReviews();
        
    }
}
