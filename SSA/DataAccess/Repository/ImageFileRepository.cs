

namespace DataAccess.Repository
{
    public class ImageFileRepository : IImageFileRepository
    {
        private readonly SSDbContext context;

        public ImageFileRepository(SSDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> AddImageFileAsync(ImageFile file)
        {
            var entry = this.context.ImageFiles.Add(file);
            return await Task.FromResult(entry.State == EntityState.Added);
        }

        public async Task<bool> DeleteImageFileAsync(ImageFile file)
        {
            var entry = this.context.ImageFiles.Remove(file);
            return await Task.FromResult(entry.State == EntityState.Deleted);
        }

        public async Task<ImageFile> GetImageFileAsync(string imageFileUID)
        {
            return await this.context.ImageFiles.FirstOrDefaultAsync(x => x.UID == imageFileUID);
        }
    }
}
