
namespace DataAccess.Entities
{
    public class PropertyAttribute
    {
        public string UID { get; set; }
        public string PropertyUID { get; set; }
        public int PropertyTypeUID { get; set; }
        public int FurnishmentTypeUID { get; set; }
        public int BedroomCount { get; set; }
        public int BathroomCount { get; set; }
        public int FloorCount { get; set; }
        public float TotalArea { get; set; }
        public bool IsBackyardAvailable { get; set; }
        public bool IsGarageAvailable { get; set; }
        public bool IsParkingSlotAvailable { get; set; }
        public int ParkingSlotCount { get; set; }   
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public string LastUpdatedDate { get; set; }

        public Property Property { get; set; }
        public PropertyType PropertyType { get; set; }
        public FurnishmentType FurnishmentType { get; set; }
    }
}
