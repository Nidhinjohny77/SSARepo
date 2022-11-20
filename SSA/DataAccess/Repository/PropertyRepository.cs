

namespace DataAccess.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly SSDbContext context;

        public PropertyRepository(SSDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddPropertyAsync(Property property)
        {
            var entry = this.context.Properties.Add(property);
            return await Task.FromResult(entry.State == EntityState.Added);
        }

        public async Task<bool> AddPropertyImageAsync(PropertyImage image)
        {
            var entry = this.context.PropertyImages.Add(image);
            return await Task.FromResult(entry.State == EntityState.Added);
        }

        public async Task<bool> AddPropertyListingAsync(PropertyListing listing)
        {
            var entry = this.context.PropertyListings.Add(listing);
            return await Task.FromResult(entry.State == EntityState.Added);
        }

        public async Task<bool> AddPropertyRentingAsync(PropertyRenting renting)
        {
            var entry = this.context.PropertyRentings.Add(renting);
            return await Task.FromResult(entry.State == EntityState.Added);
        }

        public async Task<bool> AddPropertyReviewsAsync(PropertyReview review)
        {
            var entry = this.context.PropertyReviews.Add(review);
            return await Task.FromResult(entry.State == EntityState.Added);
        }

        public async Task<bool> AddPropertyViewingAsync(PropertyViewing viewing)
        {
            var entry = this.context.PropertyViewings.Add(viewing);
            return await Task.FromResult(entry.State == EntityState.Added);
        }

        public async Task<bool> DeletePropertyAsync(Property property)
        {
            var entry = this.context.Properties.Remove(property);
            return await Task.FromResult(entry.State == EntityState.Deleted);
        }

        public async Task<bool> DeletePropertyImageAsync(PropertyImage image)
        {
            var entry = this.context.PropertyImages.Remove(image);
            return await Task.FromResult(entry.State == EntityState.Deleted);
        }

        public async Task<bool> DeletePropertyListingAsync(PropertyListing listing)
        {
            var entry = this.context.PropertyListings.Remove(listing);
            return await Task.FromResult(entry.State == EntityState.Deleted);
        }

        public async Task<bool> DeletePropertyRentingAsync(PropertyRenting renting)
        {
            var entry = this.context.PropertyRentings.Remove(renting);
            return await Task.FromResult(entry.State == EntityState.Deleted);
        }

        public async Task<bool> DeletePropertyReviewAsync(PropertyReview review)
        {
            var entry = this.context.PropertyReviews.Remove(review);
            return await Task.FromResult(entry.State == EntityState.Deleted);
        }

        public async Task<bool> DeletePropertyViewingAsync(PropertyViewing viewing)
        {
            var entry = this.context.PropertyViewings.Remove(viewing);
            return await Task.FromResult(entry.State == EntityState.Deleted);
        }

        public IQueryable<Property> GetAllProperties()
        {
            return this.context.Properties.AsQueryable();
        }

        public IQueryable<PropertyImage> GetAllPropertyImages()
        {
            return this.context.PropertyImages.AsQueryable();
        }

        public IQueryable<PropertyListing> GetAllPropertyListings()
        {
            return this.context.PropertyListings.AsQueryable();
        }

        public IQueryable<PropertyRenting> GetAllPropertyRentings()
        {
            return this.context.PropertyRentings.AsQueryable();
        }

        public IQueryable<PropertyReview> GetAllPropertyReviews()
        {
            return this.context.PropertyReviews.AsQueryable();
        }

        public IQueryable<PropertyViewing> GetAllPropertyViewings()
        {
            return this.context.PropertyViewings.AsQueryable();
        }

        public async Task<Property> GetPropertyAsync(string propertyUID)
        {
            return await this.context.Properties.FirstOrDefaultAsync(p => p.UID == propertyUID);    
        }

        public async Task<PropertyImage> GetPropertyImageAsync(string propertyImageUID)
        {
            return await this.context.PropertyImages.FirstOrDefaultAsync(p => p.UID == propertyImageUID);
        }

        public async Task<PropertyListing> GetPropertyListingAsync(string listingUID)
        {
            return await this.context.PropertyListings.FirstOrDefaultAsync(p => p.UID == listingUID);
        }

        public async Task<PropertyRenting> GetPropertyRentingAsync(string rentingUID)
        {
            return await this.context.PropertyRentings.FirstOrDefaultAsync(p => p.UID == rentingUID);
        }

        public async Task<PropertyViewing> GetPropertyViewingAsync(string viewingUID)
        {
            return await this.context.PropertyViewings.FirstOrDefaultAsync(p => p.UID == viewingUID);
        }

        public async Task<bool> UpdatePropertyAsync(Property property)
        {
            var entry = this.context.Properties.Update(property);
            return await Task.FromResult(entry.State == EntityState.Modified);
        }

        public async Task<bool> UpdatePropertyImageAsync(PropertyImage image)
        {
            var entry = this.context.PropertyImages.Update(image);
            return await Task.FromResult(entry.State == EntityState.Modified);
        }

        public async Task<bool> UpdatePropertyListingAsync(PropertyListing listing)
        {
            var entry = this.context.PropertyListings.Update(listing);
            return await Task.FromResult(entry.State == EntityState.Modified);
        }

        public async Task<bool> UpdatePropertyRentingAsync(PropertyRenting renting)
        {
            var entry = this.context.PropertyRentings.Update(renting);
            return await Task.FromResult(entry.State == EntityState.Modified);
        }

        public async Task<bool> UpdatePropertyViewingAsync(PropertyViewing viewing)
        {
            var entry = this.context.PropertyViewings.Update(viewing);
            return await Task.FromResult(entry.State == EntityState.Modified);
        }
    }
}
