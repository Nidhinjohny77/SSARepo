

namespace DataAccess.Repository
{
    public class ImageTypeRepository : IImageTypeRepository
    {
        private readonly SSDbContext context;

        public ImageTypeRepository(SSDbContext context)
        {
            this.context = context;
        }
        public IQueryable<ImageType> GetAllImageTypes()
        {
            return this.context.ImageTypes.AsQueryable();
        }

        public async Task<ImageType[]> GetAllImageTypesAsync()
        {
            return await this.context.ImageTypes.ToArrayAsync();
        }
    }
}
