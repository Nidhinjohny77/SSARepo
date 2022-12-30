

namespace DataAccess.Interface
{
    public interface IFileTypeRepository
    {
        IQueryable<FileType> GetAllFileTypes();

        Task<FileType[]> GetAllFileTypesAsync();
    }
}
