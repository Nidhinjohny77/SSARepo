
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
            return await this.context.Countries.Include(x=>x.Currency).ToArrayAsync();
        }

        public IQueryable<Country> GetAllCountries()
        {
            return this.context.Countries.AsQueryable();
        }
    }
}
