

namespace DataAccess.Entities
{
    public class TenantPreference
    {
        public string UID { get; set; }
        public string TenantUID { get; set; }
        public int PropertyTypeUID { get; set; }
        public int FurnishTypeUID { get; set; }
        public int? PreferedTenancyTypeUID { get; set; }
        public int? PreferedBedRoomCount { get; set; }
        public int? PreferedBathRoomCount { get; set; }
        public int? PreferedOccupantCount { get; set; }
        public bool? IsSharingPrefered { get; set; }
        public bool? IsAttachedBathroomPrefered { get; set; }
        public bool? IsRentIncludingBillsPrefered { get; set; }       
        public int? PreferedTenancyPeriodInMonths { get; set; }
        public string? PreferedLocations { get; set; }
        public double? StartRangeAmount { get; set; }
        public double? EndRangeAmount { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public Tenant Tenant { get; set; }
        public PropertyType PropertyType { get; set; }
        public FurnishType FurnishType { get; set; }


    }
}
