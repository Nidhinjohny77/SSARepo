

namespace DataAccess.Entities
{
    public class Currency
    {
        public int UID { get; set; }
        public int CountryUID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Symbol { get; set; }  
        public Country Country { get; set; }    
    }
}
