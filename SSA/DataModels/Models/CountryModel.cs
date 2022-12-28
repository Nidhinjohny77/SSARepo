

namespace DataModels.Models
{
    public class CountryModel
    {
        public int UID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public CurrencyModel Currency { get; set; }
    }
}
