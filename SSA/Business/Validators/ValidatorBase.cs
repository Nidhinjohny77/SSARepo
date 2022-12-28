

namespace Business.Validators
{
    public abstract class ValidatorBase
    {
        protected readonly IUnitOfWork uow;

        protected ValidatorBase(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        protected string GetRole(string loggedInUser)
        {
            var user=this.uow.UserRepository.GetUserByUIDAsync(loggedInUser).Result;
            var role=this.uow.RolesRepository.GetAllRoles().Where(r=>r.UID==user.RoleUID).FirstOrDefault();
            return role==null?null:role.Name;
        }
    }
}
