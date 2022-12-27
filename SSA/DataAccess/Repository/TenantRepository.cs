
namespace DataAccess.Repository
{
    public class TenantRepository:ITenantRepository
    {
        private readonly SSDbContext context;

        public TenantRepository(SSDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateTenantAsync(Tenant tenant)
        {
            var entry=this.context.Tenants.Add(tenant);
            return await Task.FromResult(entry.State==EntityState.Added);
        }

        public async Task<bool> CreateTenantPreferenceAsync(TenantPreference tenantPreference)
        {
            var entry = this.context.TenantPreferences.Add(tenantPreference);
            return await Task.FromResult(entry.State == EntityState.Added);
        }

        public async Task<bool> DeleteTenantAsync(Tenant tenant)
        {
            var entry = this.context.Tenants.Remove(tenant);
            return await Task.FromResult(entry.State == EntityState.Deleted);
        }

        public async Task<bool> DeleteTenantPreferenceAsync(TenantPreference tenantPreference)
        {
            var entry = this.context.TenantPreferences.Remove(tenantPreference);
            return await Task.FromResult(entry.State == EntityState.Deleted);
        }

        public IQueryable<TenantPreference> GetAllTenantPreferences()
        {
            return this.context.TenantPreferences.AsQueryable();
        }

        public IQueryable<Tenant> GetAllTenants()
        {
            return this.context.Tenants.AsQueryable();
        }

        public async Task<Tenant> GetTenantAsync(string tenantUID)
        {
            var tenant= this.GetAllTenants().Where(x=>x.UID==tenantUID).FirstOrDefault();
            return await Task.FromResult<Tenant>(tenant);
        }

        public async Task<Tenant> GetTenantByUserUIDAsync(string userUID)
        {
            var tenant = this.GetAllTenants().Where(x => x.UserUID == userUID).FirstOrDefault();
            return await Task.FromResult<Tenant>(tenant);
        }

        public async Task<TenantPreference> GetTenantPreferenceAsync(string tenantUID)
        {
            var tenantPreference = this.GetAllTenantPreferences().Where(x => x.TenantUID == tenantUID).FirstOrDefault();
            return await Task.FromResult<TenantPreference>(tenantPreference);
        }

        public async Task<TenantPreference> GetTenantPreferenceByUIDAsync(string UID)
        {
            var tenantPreference = this.GetAllTenantPreferences().Where(x => x.UID == UID).FirstOrDefault();
            return await Task.FromResult<TenantPreference>(tenantPreference);
        }

        public async Task<bool> UpdateTenantAsync(Tenant tenant)
        {
            var entry = this.context.Tenants.Update(tenant);
            return await Task.FromResult(entry.State == EntityState.Modified);
        }

        public async Task<bool> UpdateTenantPreferenceAsync(TenantPreference tenantPreference)
        {
            var entry = this.context.TenantPreferences.Update(tenantPreference);
            return await Task.FromResult(entry.State == EntityState.Modified);
        }
    }
}
