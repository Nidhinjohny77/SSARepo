

namespace Business.Manager
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IUnitOfWork uow;
        public AuthenticationManager(IUnitOfWork uow)
        {
            this.uow= uow;
        }

        public async Task<User> GetUserAsync(string userName, string password)
        {
            var userRepo = this.uow.UserRepository;
            var user=await userRepo.GetUserAsync(userName);
            
            if(IsAuthenticated(user,password))
            {
                return await Task.FromResult<User>(user);
            }
            else
            {
                return await Task.FromResult<User>(null);   
            }
        }

        private bool IsAuthenticated(User user,string password)
        {
            return user != null && user.Password == password;
        }
    }
}
