﻿
namespace DataAccess.Entities
{
    public  class User
    {
        public string UID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }
        public string RoleUID { get; set; }
        public Role Role { get; set; }

    }
}
