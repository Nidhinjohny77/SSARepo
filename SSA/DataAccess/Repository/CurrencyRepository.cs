

namespace DataAccess.Repository
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly SSDbContext context;

        public CurrencyRepository(SSDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Currency> GetAllCurrencies()
        {
            return this.context.Currencies.AsQueryable();
        }

        public async Task<Currency[]> GetAllCurrenciesAsync()
        {
            return await this.context.Currencies.ToArrayAsync();
        }
    }
}
