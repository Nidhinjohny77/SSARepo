

namespace DataAccess.Entities
{
    public class Country
    {
        public int UID { get; set; }
        public int CurrencyUID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Continent { get; set; }

        public Currency Currency { get; set; }
    }
}
