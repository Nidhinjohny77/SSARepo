

namespace DataAccess.Entities
{
    public class Property
    {
        public string UID { get; set; }
        public string LandlordUID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public int CountryUID { get; set; }
        public float Ratings { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public Landlord Landlord { get; set; }  
        public Country Country { get; set; }
        public PropertyAttribute PropertyAttribute { get; set; }
        public List<PropertyImage> Images { get; set; }
        public List<PropertyListing> Listings { get; set; }
        public List<PropertyReview> Reviews { get; set; }   

        
    }
}
