
namespace DataAccess.Entities
{
    public  class User
    {
        public long UID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }
        public Role Role { get; set; }

    }
}
