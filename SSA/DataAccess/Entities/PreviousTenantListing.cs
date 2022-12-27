
namespace DataAccess.Entities
{
    public class PreviousTenantListing
    {
        public string UID { get; set; }
        public string RentedUserUID { get; set; }
        public string PropertyListingUID { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public PropertyListing PropertyListing { get; set; }

    }
}
