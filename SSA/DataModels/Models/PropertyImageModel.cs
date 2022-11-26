

namespace DataModels.Models
{
    public class PropertyImageModel
    {
        public string UID { get; set; }
        public string PropertyUID { get; set; }

        public string ImageFileUID { get; set; }
        public bool IsActive { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public ImageModel Image { get; set; }
    }
}
