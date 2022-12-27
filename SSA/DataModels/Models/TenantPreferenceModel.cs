

namespace DataModels.Models
{
    public class TenantPreferenceModel
    {
        public string UID { get; set; }
        public string TenantUID { get; set; }
        public int PropertyTypeUID { get; set; }
        public int FurnishTypeUID { get; set; }
        public int? PreferedTenancyTypeUID { get; set; }
        public int PreferedBedRoomCount { get; set; }
        public int PreferedBathRoomCount { get; set; }
        public int PreferedOccupantCount { get; set; }
        public bool IsSharingPrefered { get; set; }
        public bool IsAttachedBathroomPrefered { get; set; }
        public bool IsRentIncludingBillsPrefered { get; set; }
        public int TenantTypeUID { get; set; }
        public int PreferedTenancyPeriod { get; set; }
        public double? StartRangeAmount { get; set; }
        public double? EndRangeAmount { get; set; }
        public string[] PreferedLocations { get; set; }
        public bool IsActive { get; set; }
    }
}
