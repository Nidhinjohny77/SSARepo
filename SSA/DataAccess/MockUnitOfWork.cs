

namespace DataAccess
{
    public class MockUnitOfWork : IUnitOfWork
    {
        private readonly SSDbContext context;

        public MockUnitOfWork(SSDbContext context)
        {
                this.context = context;
        }
        public IStudentRepository StudentRepository => throw new NotImplementedException();

        public IUniversityRepository UniversityRepository => throw new NotImplementedException();

        public IUserRepository UserRepository => new DefaultRepository();

        public void Dispose()
        {
            
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Task.FromResult(1);  
        }
    }
}
