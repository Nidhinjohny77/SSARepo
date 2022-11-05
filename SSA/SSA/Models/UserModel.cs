using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSA.Models
{
    public class UserModel
    {
        public long UID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public RoleModel Role { get; set; }
    }
}
