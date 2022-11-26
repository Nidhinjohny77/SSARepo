
namespace DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        SSDbContext context = null;
        public UserRepository(SSDbContext context)
        {
            this.context = context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var entry=await this.context.Users.AddAsync(user);
            if(entry.State == EntityState.Added)
            {
                return await Task.FromResult<User>(user);
            }
            return await Task.FromResult<User>(null);
        }

        public async Task<bool> DeleteUserAsync(User user)
        {
            var entry = this.context.Users.Remove(user);
            return await Task.FromResult(entry.State == EntityState.Deleted);
        }

        public async Task<User[]> GetAllUsersAsync()
        {
            return await this.context.Users.ToArrayAsync();
        }

        public async Task<User> GetUserAsync(string userName)
        {
            return await this.context.Users.FirstOrDefaultAsync(x=>x.UserName==userName);
        }

        public async Task<User> GetUserByUIDAsync(string userUID)
        {
            return await this.context.Users.FirstOrDefaultAsync(x => x.UID == userUID);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            var entry = this.context.Users.Update(user);
            return await Task.FromResult(entry.State == EntityState.Modified);
        }
    }
}
