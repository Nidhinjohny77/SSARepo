

namespace DataModels.Models
{
    public class PropertyListingModel
    {
        public string UID { get; set; }
        public string PropertyUID { get; set; }
        public string ListingDate { get; set; }
        public double ListingAmount { get; set; }
        public string Description { get; set; }
        public int Listedby { get; set; }
        public int ListingStatus { get; set; }
        public bool IsCTIAvailableForSale { get; set; } 
        public bool IsActive { get; set; }

        public List<PropertyViewingModel> Viewings { get; set; }
        public List<PropertyRentingModel> Rentings { get; set; }
    }
}
