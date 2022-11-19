
namespace DataAccess.Entities
{
    public class PropertyImage
    {
        public string PropertyUID { get; set; }
        public string ImageFileUID { get; set; }
        public bool IsActive { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}
