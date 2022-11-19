

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
            modelBuilder.Entity<User>(entity => entity.HasOne(p=>p.Role).WithOne());
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<University> Universities { get; set; } 
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Landlord> Landlords { get; set; }
        public DbSet<Property> Properties { get; set; } 
        public DbSet<PropertyImage> PropertyImages { get; set; }   
        public DbSet<PropertyListing> PropertyListings { get; set; }
        public DbSet<PropertyViewing> PropertyViewings { get; set; }   
        public DbSet<PropertyRenting> PropertyRentings { get; set; }   
        public DbSet<PropertyReview> PropertyReviews { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }    
    }
}
