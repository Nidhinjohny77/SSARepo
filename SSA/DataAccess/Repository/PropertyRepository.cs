

namespace DataAccess.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly SSDbContext context;

        public PropertyRepository(SSDbContext context)
        {
            this.context = context;
        }


        public Task<Property> CreatePropertyAsync(Property property)
        {
            throw new NotImplementedException();
        }

        public Task<PropertyImage> CreatePropertyImageAsync(PropertyImage image)
        {
            throw new NotImplementedException();
        }

        public Task<PropertyListing> CreatePropertyListingAsync(PropertyListing listing)
        {
            throw new NotImplementedException();
        }

        public Task<PropertyRenting> CreatePropertyRentingAsync(PropertyRenting renting)
        {
            throw new NotImplementedException();
        }

        public Task<PropertyViewing> CreatePropertyViewingAsync(PropertyViewing viewing)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAllPropertyImageAsync(string propertyUID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePropertyAsync(Property property)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePropertyImageAsync(string propertyImageUID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePropertyListingAsync(PropertyListing listing)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePropertyRentingAsync(PropertyRenting renting)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePropertyViewingAsync(PropertyViewing viewing)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Property> GetAllProperties()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Property> GetAllPropertiesByLandlord(string landlordProfileUID)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PropertyImage> GetAllPropertyImages(string propertyUID)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PropertyListing> GetAllPropertyListingByLandlord(string landlordProfileUID)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PropertyListing> GetAllPropertyListings()
        {
            throw new NotImplementedException();
        }

        public IQueryable<PropertyRenting> GetAllPropertyRentingByRentedUserUID(string rentedUserUID)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PropertyViewing> GetAllPropertyViewingByLandlord(string landlordProfileUID)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PropertyViewing> GetAllPropertyViewingByStudent(string studentProfileUID)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PropertyViewing> GetAllPropertyViewings()
        {
            throw new NotImplementedException();
        }

        public Task<Property> GetPropertyAsync(string propertyUID)
        {
            throw new NotImplementedException();
        }

        public Task<PropertyListing> GetPropertyListingAsync(string listingUID)
        {
            throw new NotImplementedException();
        }

        public Task<PropertyRenting> GetPropertyRentingAsync(string rentingUID)
        {
            throw new NotImplementedException();
        }

        public Task<PropertyViewing> GetPropertyViewingAsync(string listingUID)
        {
            throw new NotImplementedException();
        }

        public Task<Property> UpdatePropertyAsync(Property property)
        {
            throw new NotImplementedException();
        }

        public Task<PropertyListing> UpdatePropertyListingAsync(PropertyListing listing)
        {
            throw new NotImplementedException();
        }

        public Task<PropertyRenting> UpdatePropertyRentingAsync(PropertyRenting renting)
        {
            throw new NotImplementedException();
        }

        public Task<PropertyViewing> UpdatePropertyViewingAsync(PropertyViewing viewing)
        {
            throw new NotImplementedException();
        }
    }
}
