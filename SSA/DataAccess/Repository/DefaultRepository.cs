
namespace DataAccess.Repository
{
    public class DefaultRepository : IUserRepository
    {
        private List<User> users;

        public DefaultRepository()
        {
            CreateDefaultUsers();
        }

        public async Task<User[]> GetAllUsersAsync()
        {
            return await Task.FromResult<User[]>(this.users.ToArray());
        }

        public async Task<User> GetUserAsync(string userName)
        {
            return await Task.FromResult<User>(this.users.FirstOrDefault(x => x.UserName == userName));
        }

        private void CreateDefaultUsers()
        {
            this.users = new List<User>()
            {
                new User()
                {
                    UID =Guid.NewGuid().ToString(),
                    UserName ="NidhinJohny77",
                    Password ="tymeof",
                    Role=new Role() { UID="1",Name="Admin"}
                },
                new User()
                {
                    UID = Guid.NewGuid().ToString(),
                    UserName = "dada777",
                    Password = "defg",
                    Role = new Role() { UID = "1", Name = "LandLord" }
                }
            };
        }
    }
}
