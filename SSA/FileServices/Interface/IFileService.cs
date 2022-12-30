

namespace FileServices.Interface
{
    public interface IFileService
    {
        Task<bool> UploadFileAsync(string fileName,Stream fileStream);

        Task<Stream> GetFileAsync(string fileName);
    }
}
