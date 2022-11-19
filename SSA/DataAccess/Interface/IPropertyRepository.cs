
namespace DataAccess.Interface
{
    public interface IPropertyRepository
    {
        Task<Property> CreatePropertyAsync(Property property);
        Task<bool> DeletePropertyAsync(Property property);
        Task<Property>UpdatePropertyAsync(Property property);
        Task<Property> GetPropertyAsync(string propertyUID);
        IQueryable<Property> GetAllPropertiesByLandlord(string landlordProfileUID);
        IQueryable<Property> GetAllProperties();
        Task<PropertyImage> CreatePropertyImageAsync(PropertyImage image);
        IQueryable<PropertyImage> GetAllPropertyImages(string propertyUID);
        Task<bool> DeletePropertyImageAsync(string propertyImageUID);
        Task<bool> DeleteAllPropertyImageAsync(string propertyUID);

        Task<PropertyListing> CreatePropertyListingAsync(PropertyListing listing);
        Task<bool> DeletePropertyListingAsync(PropertyListing listing);
        Task<PropertyListing> UpdatePropertyListingAsync(PropertyListing listing);
        Task<PropertyListing> GetPropertyListingAsync(string listingUID);
        IQueryable<PropertyListing> GetAllPropertyListingByLandlord(string landlordProfileUID);
        IQueryable<PropertyListing> GetAllPropertyListings();

        Task<PropertyViewing> CreatePropertyViewingAsync(PropertyViewing viewing);
        Task<bool> DeletePropertyViewingAsync(PropertyViewing viewing);
        Task<PropertyViewing> UpdatePropertyViewingAsync(PropertyViewing viewing);
        Task<PropertyViewing> GetPropertyViewingAsync(string listingUID);
        IQueryable<PropertyViewing> GetAllPropertyViewingByLandlord(string landlordProfileUID);
        IQueryable<PropertyViewing> GetAllPropertyViewingByStudent(string studentProfileUID);
        IQueryable<PropertyViewing> GetAllPropertyViewings();

        Task<PropertyRenting> CreatePropertyRentingAsync(PropertyRenting renting);
        Task<bool> DeletePropertyRentingAsync(PropertyRenting renting);
        Task<PropertyRenting> UpdatePropertyRentingAsync(PropertyRenting renting);
        Task<PropertyRenting> GetPropertyRentingAsync(string rentingUID);
        IQueryable<PropertyRenting> GetAllPropertyRentingByRentedUserUID(string rentedUserUID);
    }
}
