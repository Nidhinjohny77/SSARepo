
namespace DataModels.Models
{
    public class TenantModel
    {
        public string UID { get; set; }
        public string UserUID { get; set; }
        public int TenancyTypeUID { get; set; }
        public string CountryCode { get; set; }      
        public string Address { get; set; }
        public string DOB { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        
       
    }
}
