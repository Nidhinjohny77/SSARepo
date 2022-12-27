

namespace DataAccess.Repository
{
    public class PropertyTypeRepository : IPropertyTypeRepository
    {
        private readonly SSDbContext context;

        public PropertyTypeRepository(SSDbContext context)
        {
            this.context = context;
        }

        public IQueryable<PropertyType> GetAllPropertyTypes()
        {
            return this.context.PropertyTypes.AsQueryable();
        }

        public async Task<PropertyType[]> GetAllPropertyTypesAsync()
        {
            return await this.context.PropertyTypes.ToArrayAsync();
        }
    }
}
