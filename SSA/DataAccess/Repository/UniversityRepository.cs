
namespace DataAccess.Repository
{
    public class UniversityRepository : IUniversityRepository
    {
        SSDbContext context = null;
        public UniversityRepository(SSDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddUniversityAsync(University university)
        {
            var entry=this.context.Universities.Add(university);
            return await Task.FromResult(entry.State==EntityState.Added);

        }

        public async  Task<bool> DeleteUniversityAsync(University university)
        {
            var entry=this.context.Universities.Remove(university);
            return await Task.FromResult(entry.State == EntityState.Deleted);
        }

        public IQueryable<University> GetAllUniversities()
        {
            return this.context.Universities.AsQueryable<University>();
        }

        public async Task<University> GetUniversityByIdAsync(string uid)
        {
            return await this.context.Universities.FirstAsync<University>(x=>x.UID==uid);
        }

        public async Task<University> GetUniversityByNameAsync(string name)
        {
            return await this.context.Universities.FirstAsync<University>(x => x.Name == name);
        }

        public async Task<bool> UpdateUniversityAsync(University university)
        {
            var entry = this.context.Universities.Update(university);
            return await Task.FromResult(entry.State == EntityState.Modified);
        }
    }
}
