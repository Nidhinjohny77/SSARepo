

namespace DataModels.Models
{
    public class PropertyRentingModel
    {
        public string UID { get; set; }
        public string PropertyListingUID { get; set; }
        public double RentAmount { get; set; }
        public double AdvanceAmount { get; set; }
        public string RentedUserUID { get; set; }
        public DateTime RentStartDate { get; set; }
        public DateTime RentEndDate { get; set; }
        public int RentPaymentFrequency { get; set; }
        public bool IsActive { get; set; }
    }
}
