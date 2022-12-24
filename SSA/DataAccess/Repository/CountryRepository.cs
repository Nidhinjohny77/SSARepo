
namespace DataAccess.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly SSDbContext context;

        public CountryRepository(SSDbContext context)
        {
            this.context = context;
        }
        public async Task<Country[]> GetAllCountriesAsync()
        {
            return await this.context.Countries.ToArrayAsync();
        }
    }
}
