

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
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Role>().HasKey(r=>r.UID);

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().HasKey(u => u.UID);
            modelBuilder.Entity<User>(entity => entity.HasOne(p => p.Role));

            modelBuilder.Entity<University>().ToTable("University");
            modelBuilder.Entity<University>().HasKey(u => u.UID);

            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Student>().HasKey(s => s.ProfileUID);
            modelBuilder.Entity<Student>().HasOne(s => s.User).WithOne().HasForeignKey<Student>(s => s.UserUID);
            //Note:- the implementation of 'HasForeignKey("")' with string parameter is normally used with shadow foreign keys.So dont 
            //what will be the impact used with properly defined foreign key.
            modelBuilder.Entity<Student>().HasOne(s => s.University).WithOne().HasForeignKey<Student>(s => s.UniversityUID);

            modelBuilder.Entity<Landlord>().ToTable("Landlord");
            modelBuilder.Entity<Landlord>().HasKey(l=>l.ProfileUID);
            modelBuilder.Entity<Landlord>().HasOne(s=>s.User).WithOne().HasForeignKey<Landlord>(s => s.UserUID);
        }

       public DbSet<Student> Students { get; set; }
       public DbSet<University> Universities { get; set; } 
       public DbSet<User> Users { get; set; }
       public DbSet<Role> Roles { get; set; }
       public DbSet<Landlord> Landlords { get; set; }
        //public DbSet<Property> Properties { get; set; } 
        //public DbSet<PropertyImage> PropertyImages { get; set; }   
        //public DbSet<PropertyListing> PropertyListings { get; set; }
       // public DbSet<PropertyViewing> PropertyViewings { get; set; }   
        //public DbSet<PropertyRenting> PropertyRentings { get; set; }   
        //public DbSet<PropertyReview> PropertyReviews { get; set; }
        //public DbSet<ImageFile> ImageFiles { get; set; }    
    }
}
