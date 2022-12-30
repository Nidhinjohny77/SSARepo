

namespace DataModels.Models
{
    public class PropertyImageModel
    {
        public string UID { get; set; }
        public string PropertyUID { get; set; }
        public int ImageTypeUID { get; set; }
        public int ImageFileTypeUID { get; set; }
        public string FileName { get; set; }      
        public bool IsActive { get; set; }
    }
}
