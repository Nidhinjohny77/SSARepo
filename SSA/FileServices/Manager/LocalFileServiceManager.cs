

namespace FileServices.Manager
{
    public class LocalFileServiceManager:IFileService
    {
        private readonly IConfiguration configuration;

        public LocalFileServiceManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// The file name should be fully qualified with appropriate extension type.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileStream"></param>
        /// <returns></returns>
        public async Task<bool> UploadFileAsync(string fileName,Stream fileStream)
        {
            var uploadDirectoryPath = this.configuration.GetSection("UploadDirectory").Value+"/"+fileName;
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

        public async Task<Stream> GetFileAsync(string fileName)
        {
            MemoryStream stream=new MemoryStream();
            var uploadDirectoryPath = this.configuration.GetSection("UploadDirectory").Value + "/" + fileName;
            if (uploadDirectoryPath == null)
            {
                return await Task.FromResult<Stream>(null);
            }
            else
            {
                using (var fs = new FileStream(uploadDirectoryPath, FileMode.Open))
                {
                    fs.CopyToAsync(stream);
                }
                stream.Position = 0;
                return await Task.FromResult<Stream>(stream);
            }
        }
    }
}
