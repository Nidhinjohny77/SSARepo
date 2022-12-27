

namespace DataAccess.Entities
{
    public class PropertyViewing
    {
        public string UID { get; set; }
        public string PropertyListingUID { get; set; }
        public string TenantUID { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int Status { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public Tenant Tenant { get; set; }
        public PropertyListing PropertyListing { get; set; }    
    }
}
