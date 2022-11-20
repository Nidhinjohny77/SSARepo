
namespace DataAccess.Interface
{
    public interface IImageFileRepository
    {
        Task<bool> AddImageFileAsync(ImageFile file);
        Task<bool> DeleteImageFileAsync(ImageFile file);
        Task<ImageFile> GetImageFileAsync(string imageFileUID);

    }
}
