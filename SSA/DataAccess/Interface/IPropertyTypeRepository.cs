

namespace DataAccess.Interface
{
    public interface IPropertyTypeRepository
    {
        IQueryable<PropertyType> GetAllPropertyTypes();

        Task<PropertyType[]> GetAllPropertyTypesAsync();
    }
}
