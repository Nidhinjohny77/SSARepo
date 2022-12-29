
namespace DataModels.Models
{
    public class PropertyAttributeModel
    {
        public string UID { get; set; }
        public string PropertyUID { get; set; }
        public int PropertyTypeUID { get; set; }
        public int FurnishTypeUID { get; set; }
        public int BedroomCount { get; set; }
        public int BathroomCount { get; set; }
        public int MaxOccupantCount { get; set; }
        public int FloorCount { get; set; }
        public float TotalAreaInSqFT { get; set; }
        public bool IsBackyardAvailable { get; set; }
        public bool IsGarageAvailable { get; set; }
        public bool IsParkingSlotAvailable { get; set; }
        public int ParkingSlotCount { get; set; }
        public bool IsActive { get; set; }
    }
}
