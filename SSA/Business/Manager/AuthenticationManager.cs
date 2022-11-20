

namespace Business.Manager
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public AuthenticationManager(IUnitOfWork uow,IMapper mapper)
        {
            this.uow= uow;
            this.mapper=mapper;
        }

        public async Task<UserModel> GetUserAsync(string userName, string password)
        {
            var userRepo = this.uow.UserRepository;
            var user=await userRepo.GetUserAsync(userName);
            
            if(IsAuthenticated(user,password))
            {
                var model=this.mapper.Map<UserModel>(user);
                return await Task.FromResult<UserModel>(model);
            }
            else
            {
                return await Task.FromResult<UserModel>(null);   
            }
        }

        private bool IsAuthenticated(User user,string password)
        {
            return user != null && user.Password == password;
        }
    }
}
