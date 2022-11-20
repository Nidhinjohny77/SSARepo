

namespace DataAccess.Entities
{
    public class PropertyListing
    {
        public string UID { get; set; }
        public string PropertyUID { get; set; }
        public DateTime ListingDate { get; set; }
        public double ListingAmount { get; set; }
        public string Description { get; set; }
        public int Listedby { get; set; }
        public int ListingStatus { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        
        public List<PropertyViewing> Viewings { get; set; }
        public List<PropertyRenting> Rentings { get; set; } 
    }
}
