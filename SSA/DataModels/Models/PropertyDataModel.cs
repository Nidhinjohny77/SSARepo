

namespace DataModels.Models
{
    public class PropertyDataModel
    {
        public string PropertyUID { get; set; }
        public string PropertyListingUID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Landmark { get; set; }
        public bool IsNew { get; set; } = true;
        public bool IsStudentFriendly { get; set; } = true;
        public bool IsPetsAllowed { get; set; }
        public bool IsParkingAvailable { get; set; }
        public bool IsPartyingAllowed { get; set; }
        public bool IsSmokingAllowed { get; set; }
        public bool IsSharingAllowed { get; set; }
        public string AvailableDate { get; set; }
        public int BedRoomCount { get; set; }
        public int BathRoomCount { get; set; }
        public int AvailableParkingSlots { get; set; }
        public int AllowedOccupantCount { get; set; }
        public double Price { get; set; }
        public ImageModel ThumbNailImage { get; set; }

        public PropertyImageModel ThumbNailImageData { get; set; }
    }
}
