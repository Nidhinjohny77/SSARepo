
namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        SSDbContext context = null;
        public UnitOfWork(SSDbContext context)
        {
            this.context = context;
        }
        public IStudentRepository StudentRepository => new StudentRepository(this.context);

        public IUniversityRepository UniversityRepository => new UniversityRepository(this.context);

        public IUserRepository UserRepository => new UserRepository(this.context);

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
