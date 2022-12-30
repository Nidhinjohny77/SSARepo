
namespace Business.Interface
{
    public interface IMasterDataManager
    {
        Task<CountryModel[]> GetAllCountriesAsync();
        Task<RoleModel[]> GetAllRolesAsync();

        Task<ItemModel[]> GetAllItemsAsync();
        Task<CurrencyModel[]> GetAllCurrenciesAsync();
        Task<FurnishTypeModel[]> GetAllFurnishTypesAsync();
        Task<PropertyTypeModel[]> GetAllPropertyTypesAsync();
        Task<TenancyTypeModel[]> GetAllTenancyTypesAsync();
        Task<UniversityModel[]> GetAllUniversitiesAsync();
        Task<ImageType[]> GetAllImageTypesAsync();
        Task<ImageFileType[]> GetAllImageFileTypesAsync();
    }
}
