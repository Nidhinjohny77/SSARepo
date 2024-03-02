

namespace FileServices.Manager
{
    public class LocalFileServiceManager:IFileService
    {
        private readonly string uploadDirectory;

        public LocalFileServiceManager(string uploadDirectory)
        {
            this.uploadDirectory = uploadDirectory+"/";
        }

        /// <summary>
        /// The file name should be fully qualified with appropriate extension type.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileStream"></param>
        /// <returns></returns>
        public async Task<bool> UploadFileAsync(string fileName,Stream fileStream)
        {
            var uploadDirectoryPath = this.uploadDirectory + fileName;
            if(uploadDirectoryPath == null)
            {
                return await Task.FromResult(false);
            }
            else
            {
                using(var fs=new FileStream(uploadDirectoryPath, FileMode.Create))
                {
                    await fileStream.CopyToAsync(fs);
                }

                return await Task.FromResult(File.Exists(uploadDirectoryPath));
            }
        }

        public async Task<MemoryStream> GetFileAsync(string fileName)
        {
            MemoryStream stream=new MemoryStream();
            var uploadDirectoryPath = this.uploadDirectory + fileName;
            if (uploadDirectoryPath == null)
            {
                return await Task.FromResult<MemoryStream>(null);
            }
            else
            {
                using (var fs = new FileStream(uploadDirectoryPath, FileMode.Open))
                {
                    await fs.CopyToAsync(stream);
                }
                stream.Position = 0;
                return await Task.FromResult<MemoryStream>(stream);
            }
        }

        public async Task<string> GetBase64FileAsync(string fileName)
        {
            var stream = await GetFileAsync(fileName);
            var bytes = stream.ToArray();
            var base64Encoded = Convert.ToBase64String(bytes);
            return await Task.FromResult<string>(base64Encoded);
        }
    }
}
