
using Azure.Storage.Blobs;

namespace FileServices.Manager
{
    public class AzureFileStorageService : IFileService
    {
        private const string storageContainerName = "propertyimages";
        private readonly BlobContainerClient bobContainerClient;

        public AzureFileStorageService(string connectionString)
        {
            this.bobContainerClient = new BlobContainerClient(connectionString, storageContainerName);
        }
        public async Task<MemoryStream> GetFileAsync(string fileName)
        {
            MemoryStream stream = new MemoryStream();
            BlobClient blobClient = bobContainerClient.GetBlobClient(fileName);
            await blobClient.DownloadToAsync(stream);
            return await Task.FromResult<MemoryStream>(stream);
        }

        public async Task<bool> UploadFileAsync(string fileName, Stream fileStream)
        {
            BlobClient blobClient = bobContainerClient.GetBlobClient(fileName);
            var response=await blobClient.UploadAsync(fileStream, true);
            fileStream.Close();
            return await Task.FromResult<bool>(response.GetRawResponse().Status==201);
        }
    }
}
