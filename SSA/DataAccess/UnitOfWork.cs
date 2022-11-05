
namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        SSDbContext context = null;
        public UnitOfWork(SSDbContext context)
        {
            this.context = context;
        }
        public IStudentRepository StudentRepository => throw new NotImplementedException();

        public IUniversityRepository UniversityRepository => throw new NotImplementedException();

        public IUserRepository UserRepository => new DefaultRepository();

        public void Dispose()
        {
            this.context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this.context.SaveChangesAsync();
        }
    }
}
