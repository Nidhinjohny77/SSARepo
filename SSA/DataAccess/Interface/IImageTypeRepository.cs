

namespace DataAccess.Interface
{
    public interface IImageTypeRepository
    {
        IQueryable<ImageType> GetAllImageTypes();

        Task<ImageType[]> GetAllImageTypesAsync();
    }
}
