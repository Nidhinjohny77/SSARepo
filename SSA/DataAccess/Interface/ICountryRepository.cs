

namespace DataAccess.Interface
{
    public interface ICountryRepository
    {
        Task<Country[]> GetAllCountriesAsync();
    }
}
