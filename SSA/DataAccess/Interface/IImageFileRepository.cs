
namespace DataAccess.Interface
{
    public interface IImageFileRepository
    {
        Task<bool> CreateImageFileAsync(ImageFile file);
        Task<bool> DeleteImageFileAsync(string imageFileUID);
        Task<ImageFile> GetImageFileAsync(string imageFileUID);

    }
}
