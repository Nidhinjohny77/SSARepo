

namespace DataAccess.Entities
{
    public class PropertyViewing
    {
        public string UID { get; set; }
        public string PropertyListingUID { get; set; }
        public string StudentUID { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int status { get; set; }
        public bool IsActive { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}
