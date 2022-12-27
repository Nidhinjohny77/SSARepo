
namespace DataAccess.Interface
{
    public interface ICurrencyRepository
    {
        IQueryable<Currency> GetAllCurrencies();

        Task<Currency[]> GetAllCurrenciesAsync();
    }
}
