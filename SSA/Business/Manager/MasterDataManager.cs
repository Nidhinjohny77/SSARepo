

namespace Business.Manager
{
    public class MasterDataManager : IMasterDataManager
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IRolesRepository roleRepository;
        private readonly ICountryRepository countryRepository;
        private readonly IPropertyTypeRepository propertyTypeRepository;
        private readonly ITenantTypeRepository tenantTypeRepository;
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
            this.tenantTypeRepository = this.uow.TenantTypeRepository;
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

        public async Task<RoleModel[]> GetAllRolesAsync()
        {
            var roles = this.roleRepository.GetAllRoles().ToArray();
            var result = this.mapper.Map<RoleModel[]>(roles);
            return await Task.FromResult<RoleModel[]>(result);
        }
    }
}
