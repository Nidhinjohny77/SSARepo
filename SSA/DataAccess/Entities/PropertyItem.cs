

namespace DataAccess.Entities
{
    public class PropertyItem
    {
        public int UID { get; set; }
        public int ItemUID { get; set; }
        public int Count { get; set; }
        public decimal UnitPrice { get; set; }
        public int CurrencyUID { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string LastUpdatedBy { get; set; }   
    }
}
