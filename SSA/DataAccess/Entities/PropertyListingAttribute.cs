
namespace DataAccess.Entities
{
    public class PropertyListingAttribute
    {
        public string UID { get; set; }
        public string PropertyListingUID { get; set; }
        public string PropertyAttributeUID { get; set; }
        public string Landmark { get; set; }
        public DateTime AvailableDate { get; set; }
        public int AvailableBedroomCount { get; set; }
        public int AvailableBathroomCount { get; set; }
        public int AllowedOccupantCount { get; set; }
        public bool IsNew { get; set; }
        public bool IsStudentFriendly { get; set; }
        public bool IsSharingAllowed { get; set; }
        public bool IsUnisex { get; set; }
        public bool IsPetsAllowed { get; set; }
        public bool IsChildrenAllowed { get; set; } 
        public bool IsSmokingAllowed { get; set; }
        public bool IsPartyingAllowed { get; set; }
        public bool IsParkingAvailable { get; set; }
        public int TenancyTypeUID { get; set; }
        public int? AvailableParkingSlots { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public PropertyListing PropertyListing { get; set; }
        public PropertyAttribute PropertyAttribute { get; set; }
        public TenancyType TenancyType { get; set; }  
        
    }
}
