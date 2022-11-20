using System.Security.Claims;

namespace SSA.Controllers
{
    public class SSAControllerBase:ControllerBase
    {
        private UserModel user;

        protected SSAControllerBase() : base()
        {
        }

        protected UserModel User
        {
            get
            {
                if (this.user == null)
                {
                    if (this.HttpContext.User != null)
                    {
                        var claims = this.HttpContext.User.Claims.ToList();
                        if (claims.Any())
                        {
                            this.user = new UserModel()
                            {
                                UID = claims.FirstOrDefault(x => x.Type == GlobalConstant.UserUID)?.Value,
                                UserName = claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value
                            };
                            var roleClaims = claims.FindAll(x => x.Type == ClaimTypes.Role);
                            if (roleClaims.Any())
                            {
                                var roles = new List<RoleModel>();
                                foreach (var role in roleClaims)
                                {
                                    var roleModel = new RoleModel()
                                    {
                                        Name = role.Value
                                    };
                                }
                            }
                        }
                    }
                }
                return user;
            }
        }

    }
}

