
namespace DataAccess.Repository
{
    public class UniversityRepository : IUniversityRepository
    {
        SSDbContext context = null;
        public UniversityRepository(SSDbContext context)
        {
            this.context = context;
        }

        public Task<University> AddUniversityAsync(University university)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUniversityAsync(University university)
        {
            throw new NotImplementedException();
        }

        public Task<University[]> GetAllUniversitiesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<University> GetUniversityByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<University> GetUniversityByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<University> UpdateUniversityAsync(University university)
        {
            throw new NotImplementedException();
        }
    }
}
