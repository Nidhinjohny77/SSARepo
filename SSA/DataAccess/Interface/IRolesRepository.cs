
namespace DataAccess.Interface
{
    public interface IRolesRepository
    {
        IQueryable<Role> GetAllRoles();
    }
}
