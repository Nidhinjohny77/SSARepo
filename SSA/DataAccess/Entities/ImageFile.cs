
namespace DataAccess.Entities
{
    public class ImageFile
    {
        public string UID { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public byte[] Data { get; set; }
    }
}
