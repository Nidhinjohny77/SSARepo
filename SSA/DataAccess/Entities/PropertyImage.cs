
namespace DataAccess.Entities
{
    public class PropertyImage
    {
        public string UID { get; set; }
        public string PropertyUID { get; set; }
        public string FileName { get; set; }
        public int ImageTypeUID { get; set; }
        public int ImageFileTypeUID { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public Property Property { get; set; }
        public ImageType ImageType { get; set; }    
        public ImageFileType ImageFileType { get; set; }

    }
}
