
namespace Business.Interface
{
    public interface IMasterDataManager
    {
        Task<CountryModel[]> GetAllCountriesAsync();
        Task<RoleModel[]> GetAllRolesAsync();
    }
}
