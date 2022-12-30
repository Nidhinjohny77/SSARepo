

namespace FileServices.Interface
{
    public interface IFileService
    {
        Task<bool> UploadFileAsync(string fileName,Stream fileStream);

        Task<MemoryStream> GetFileAsync(string fileName);
    }
}
