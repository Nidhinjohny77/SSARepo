

namespace DataModels.Models
{
    public class ImageModel
    {
        public string UID { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public byte[] Data { get; set; }
    }
}
