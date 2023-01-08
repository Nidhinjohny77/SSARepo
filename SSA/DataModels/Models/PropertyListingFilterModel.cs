

namespace DataModels.Models
{
    public class PropertyListingFilterModel
    {
        public string Location { get; set; }
        public double? StartRent { get; set; }
        public double? EndRent { get; set; }
        public int? BedroomCount { get; set; }
        public int? BathRoomCount { get; set; }
        public int? PropertyTypeUID { get; set; }
        public int? FurnishTypeUID { get; set; }

    }
}
