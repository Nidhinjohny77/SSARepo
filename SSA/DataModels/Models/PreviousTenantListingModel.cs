

namespace DataModels.Models
{
    public class PreviousTenantListingModel
    {
        public string UID { get; set; }
        public string RentedUserUID { get; set; }
        public string PropertyListingUID { get; set; }
        public bool IsActive { get; set; }
    }
}
