

namespace DataAccess.Repository
{
    public class ImageFileRepository : IImageFileRepository
    {
        private readonly SSDbContext context;

        public ImageFileRepository(SSDbContext context)
        {
            this.context = context;
        }
        public Task<bool> CreateImageFileAsync(ImageFile file)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteImageFileAsync(string imageFileUID)
        {
            throw new NotImplementedException();
        }

        public Task<ImageFile> GetImageFileAsync(string imageFileUID)
        {
            throw new NotImplementedException();
        }
    }
}
