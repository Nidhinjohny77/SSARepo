

namespace DataModels.Models
{
    public class CurrentTenantItemModel
    {
        public string UID { get; set; }
        public string PropertyRentingUID { get; set; }
        public int Count { get; set; }
        public decimal UnitPrice { get; set; }
        public string CurrencyCode { get; set; }
        public bool IsActive { get; set; }
        public ItemModel Item { get; set; }
    }
}
