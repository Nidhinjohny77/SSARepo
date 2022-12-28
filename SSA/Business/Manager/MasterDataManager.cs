

namespace Business.Manager
{
    public class MasterDataManager : IMasterDataManager
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IRolesRepository roleRepository;
        private readonly ICountryRepository countryRepository;
        private readonly IPropertyTypeRepository propertyTypeRepository;
        private readonly ITenancyTypeRepository tenancyTypeRepository;
        private readonly ICurrencyRepository currencyRepository;
        private readonly IItemTypeRepository itemTypeRepository;
        private readonly IItemRepository itemRepository;
        private readonly IUniversityRepository universityRepository;
        private readonly IFurnishTypeRepository furnishTypeRepository;

        public MasterDataManager(IUnitOfWork uow,IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.roleRepository = this.uow.RolesRepository;
            this.countryRepository = this.uow.CountryRepository;
            this.propertyTypeRepository = this.uow.PropertyTypeRepository;
            this.tenancyTypeRepository = this.uow.TenancyTypeRepository;
            this.currencyRepository = this.uow.CurrencyRepository;
            this.itemTypeRepository = this.uow.ItemTypeRepository;
            this.itemRepository = this.uow.ItemRepository;
            this.universityRepository = this.uow.UniversityRepository;
            this.furnishTypeRepository = this.uow.FurnishTypeRepository;
        }
        public async Task<CountryModel[]> GetAllCountriesAsync()
        {
            var countries= await this.countryRepository.GetAllCountriesAsync();
            var result=this.mapper.Map<CountryModel[]>(countries);
            return await Task.FromResult<CountryModel[]>(result);
        }

        public async Task<ItemModel[]> GetAllItemsAsync()
        {
            var items=await this.itemRepository.GetAllItemsAsync();
            var result= this.mapper.Map<ItemModel[]>(items);
            return await Task.FromResult<ItemModel[]>(result);
        }

        public async Task<RoleModel[]> GetAllRolesAsync()
        {
            var roles = this.roleRepository.GetAllRoles().ToArray();
            var result = this.mapper.Map<RoleModel[]>(roles);
            return await Task.FromResult<RoleModel[]>(result);
        }

        public async Task<CurrencyModel[]> GetAllCurrenciesAsync()
        {
            var entities = this.currencyRepository.GetAllCurrencies().ToArray();
            var result = this.mapper.Map<CurrencyModel[]>(entities);
            return await Task.FromResult<CurrencyModel[]>(result);
        }

        public async Task<FurnishTypeModel[]> GetAllFurnishTypesAsync()
        {
            var entities = this.furnishTypeRepository.GetAllFurnishTypes().ToArray();
            var result = this.mapper.Map<FurnishTypeModel[]>(entities);
            return await Task.FromResult<FurnishTypeModel[]>(result);
        }

        public async Task<PropertyTypeModel[]> GetAllPropertyTypesAsync()
        {
            var entities = this.propertyTypeRepository.GetAllPropertyTypes().ToArray();
            var result = this.mapper.Map<PropertyTypeModel[]>(entities);
            return await Task.FromResult<PropertyTypeModel[]>(result);
        }

        public async Task<TenancyTypeModel[]> GetAllTenancyTypesAsync()
        {
            var entities = this.tenancyTypeRepository.GetAllTenancyTypes().ToArray();
            var result = this.mapper.Map<TenancyTypeModel[]>(entities);
            return await Task.FromResult<TenancyTypeModel[]>(result);
        }

        public async Task<UniversityModel[]> GetAllUniversitiesAsync()
        {
            var entities = this.universityRepository.GetAllUniversities().ToArray();
            var result = this.mapper.Map<UniversityModel[]>(entities);
            return await Task.FromResult<UniversityModel[]>(result);
        }
    }
}
