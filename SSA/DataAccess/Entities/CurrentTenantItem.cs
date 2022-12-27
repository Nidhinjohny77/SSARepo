
namespace DataAccess.Entities
{
    public class CurrentTenantItem
    {
        public string UID { get; set; }
        public string PropertyRentingUID { get; set; }
        public int ItemUID { get; set; }
        public int Count { get; set; }
        public decimal UnitPrice { get; set; }
        public int CurrencyUID { get; set; }
        public bool IsActive { get; set; }

        public PropertyRenting PropertyRenting { get; set; }
        public Item Item { get; set; }
        public Currency Currency { get; set; }
    }
}
