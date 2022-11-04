

namespace Business.Manager
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IUnitOfWork uow;
        public AuthenticationManager(IUnitOfWork uow)
        {
            this.uow= uow;
        }

        public Task<UserModel> GetUser(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
