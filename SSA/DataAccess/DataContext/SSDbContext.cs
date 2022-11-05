

namespace DataAccess.DataContext
{
    public class SSDbContext:DbContext
    {
        public SSDbContext(DbContextOptions<SSDbContext> options):base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<University> Universities { get; set; } 
        public DbSet<User> Users { get; set; }
    }
}
