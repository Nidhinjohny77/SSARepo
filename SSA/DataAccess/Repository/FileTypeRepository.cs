

namespace DataAccess.Repository
{
    public class FileTypeRepository : IFileTypeRepository
    {
        private readonly SSDbContext context;

        public FileTypeRepository(SSDbContext context)
        {
            this.context = context;
        }
        public IQueryable<FileType> GetAllFileTypes()
        {
            return this.context.FileTypes.AsQueryable();
        }

        public async Task<FileType[]> GetAllFileTypesAsync()
        {
            return await this.context.FileTypes.ToArrayAsync();
        }
    }
}
