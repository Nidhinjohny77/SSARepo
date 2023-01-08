

namespace FileServices.Interface
{
    public interface IFileService
    {
        Task<bool> UploadFileAsync(string fileName,Stream fileStream);

        Task<MemoryStream> GetFileAsync(string fileName);

        Task<string> GetBase64FileAsync(string fileName);
    }
}
