
namespace FileServices.Manager
{
    public class AzureFileStorageService : IFileService
    {
        private readonly IConfiguration configuration;

        public AzureFileStorageService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public Task<MemoryStream> GetFileAsync(string fileName)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UploadFileAsync(string fileName, Stream fileStream)
        {
            throw new NotImplementedException();
        }
    }
}
