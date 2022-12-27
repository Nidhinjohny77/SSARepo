
namespace DataAccess.Entities
{
    public class Tenant
    {
        public string UID { get; set; }
        public string UserUID { get; set; }
        public int CountryUID{ get; set; }
        public int TenantTypeUID { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }


        public User User { get; set; }
        public Country Country { get; set; }
        public TenancyType TenantType { get; set; }
        public List<PropertyViewing> Viewings { get; set; }

    }
}
