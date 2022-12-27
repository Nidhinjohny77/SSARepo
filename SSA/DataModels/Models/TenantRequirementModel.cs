

namespace DataModels.Models
{
    public class TenantRequirementModel
    {
        public string UID { get; set; }
        public string UserUID { get; set; }
        public string PropertyTypeCode { get; set; }
        public string FurnishmentTypeCode { get; set; }
        public int PreferedBedRoomCount { get; set; }
        public int PreferedBathRoomCount { get; set; }
        public int PreferedOccupantCount { get; set; }
        public bool IsSharingPrefered { get; set; }
        public bool IsAttachedBathroomPrefered { get; set; }
        public bool IsRentIncludingBillsPrefered { get; set; }
        public int TenantTypeUID { get; set; }
        public int PreferedTenancyPeriod { get; set; }
        public bool IsActive { get; set; }
    }
}
