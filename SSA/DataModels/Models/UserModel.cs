

namespace DataModels.Models
{
    public class UserModel
    {
        public long UID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public RoleModel Role { get; set; }
    }
}
