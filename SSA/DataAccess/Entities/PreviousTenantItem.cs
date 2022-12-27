
namespace DataAccess.Entities
{
    public class PreviousTenantItem
    {
        public string UID { get; set; }
        public string PreviousTenantListingUID { get; set; }
        public int ItemUID { get; set; }
        public int Count { get; set; }
        public decimal UnitPrice { get; set; }
        public string CurrencyCode { get; set; }
        public bool IsActive { get; set; }

        public PreviousTenantListing PreviousTenantListing { get; set; }
        public Item Item { get; set; }
    }
}
