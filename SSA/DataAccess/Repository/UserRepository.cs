
namespace DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        SSDbContext context = null;
        public UserRepository(SSDbContext context)
        {
            this.context = context;
        }
        public async Task<User[]> GetAllUsersAsync()
        {
            return await this.context.Users.ToArrayAsync();
        }

        public async Task<User> GetUserAsync(string userName)
        {
            return await this.context.Users.FirstOrDefaultAsync(x=>x.UserName==userName);
        }
    }
}
