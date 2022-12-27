

namespace DataModels.Models
{
    public class PropertyViewingModel
    {
        public string UID { get; set; }
        public string PropertyListingUID { get; set; }
        public string TenantUID { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int Status { get; set; }
        public bool IsActive { get; set; }
    }
}
