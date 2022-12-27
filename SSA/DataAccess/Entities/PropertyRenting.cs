
namespace DataAccess.Entities
{
    public class PropertyRenting
    {
        public string UID { get; set; }
        public string PropertyListingUID { get; set; }
        public double RentAmount { get; set; }
        public double AdvanceAmount { get; set; }
        public string TenantUID { get; set; }
        public DateTime RentStartDate { get; set; }
        public DateTime RentEndDate { get; set; }
        public int RentPaymentFrequency { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public PropertyListing PropertyListing { get; set; }
        public Tenant Tenant { get; set; }

    }
}
