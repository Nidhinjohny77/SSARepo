

namespace DataModels.Models
{
    public class PreviousTenantItemModel
    {
        public string UID { get; set; }
        public int Count { get; set; }
        public decimal UnitPrice { get; set; }
        public string CurrencyCode { get; set; }
        public bool IsActive { get; set; }

        public PreviousTenantListingModel PreviousTenantListing { get; set; }
        public ItemModel Item { get; set; }
    }
}
