

namespace DataAccess.Interface
{
    public interface ICountryRepository
    {
        IQueryable<Country> GetAllCountries();
        Task<Country[]> GetAllCountriesAsync();
    }
}
