

namespace DataAccess.Repository
{
    public class RolesRepository : IRolesRepository
    {
        private readonly SSDbContext context;

        public RolesRepository(SSDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Role> GetAllRoles()
        {
            return this.context.Roles.AsQueryable();
        }
    }
}
