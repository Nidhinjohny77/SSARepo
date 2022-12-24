

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
            modelBuilder.Entity<PropertyType>().ToTable("PropertyType");
            modelBuilder.Entity<PropertyType>().HasKey(pt => pt.UID);
            modelBuilder.Entity<PropertyType>().HasData(new PropertyType() { UID = 1, Code = "FLT", Description="Flat" });
            modelBuilder.Entity<PropertyType>().HasData(new PropertyType() { UID = 1, Code = "HSTL", Description = "Hostel" });
            modelBuilder.Entity<PropertyType>().HasData(new PropertyType() { UID = 1, Code = "PG", Description = "Paying Guest" });
            modelBuilder.Entity<PropertyType>().HasData(new PropertyType() { UID = 1, Code = "HSO", Description = "House in Single Occupancy" });
            modelBuilder.Entity<PropertyType>().HasData(new PropertyType() { UID = 1, Code = "HMO", Description = "House in Multiple Occupancy" });

            modelBuilder.Entity<FurnishmentType>().ToTable("FurnishmentType");
            modelBuilder.Entity<FurnishmentType>().HasKey(ft => ft.UID);
            modelBuilder.Entity<FurnishmentType>().HasData(new FurnishmentType() { UID = 1, Code = "FULL", Description = "Fully Furnished" });
            modelBuilder.Entity<FurnishmentType>().HasData(new FurnishmentType() { UID = 2, Code = "SEMI", Description = "Semi Furnished" });
            modelBuilder.Entity<FurnishmentType>().HasData(new FurnishmentType() { UID = 3, Code = "NF", Description = "Non Furnished" });

            modelBuilder.Entity<ItemType>().ToTable("ItemType");
            modelBuilder.Entity<ItemType>().HasKey(ft => ft.UID);
            modelBuilder.Entity<ItemType>().HasData(new ItemType() { UID = 1, Name = "Furniture", Description = "Furnitures available." });
            modelBuilder.Entity<ItemType>().HasData(new ItemType() { UID = 2, Name = "Electrical", Description = "Electrical items available." });
            modelBuilder.Entity<ItemType>().HasData(new ItemType() { UID = 3, Name = "Gas Equipment", Description = "Equipments to deal the cooking gas." });
            modelBuilder.Entity<ItemType>().HasData(new ItemType() { UID = 4, Name = "Kitchen Utensil", Description = "Kitchen utensils." });
            modelBuilder.Entity<ItemType>().HasData(new ItemType() { UID = 5, Name = "Bathroom Fittings", Description = "Bathroom fittings." });
            modelBuilder.Entity<ItemType>().HasData(new ItemType() { UID = 6, Name = "Heat Fittings", Description = "Heating fittings." });

            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Role>().HasKey(r=>r.UID);
            modelBuilder.Entity<Role>().HasData(new Role() { UID = 1, Name = "Admin" });
            modelBuilder.Entity<Role>().HasData(new Role() { UID =2, Name = "Student" });
            modelBuilder.Entity<Role>().HasData(new Role() { UID = 3, Name = "Landlord" });
            modelBuilder.Entity<Role>().HasData(new Role() { UID = 4, Name = "University" });
            modelBuilder.Entity<Role>().HasData(new Role() { UID = 5, Name = "Consultant" });

            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<Country>().HasKey(c => c.UID);
            modelBuilder.Entity<Country>().HasData(new Country() { UID = 1, Name = "United Kingdom",Code="UK",Continent="Europe" });
            modelBuilder.Entity<Country>().HasData(new Country() { UID = 2, Name = "India", Code = "IND", Continent = "Asia" });
            modelBuilder.Entity<Country>().HasData(new Country() { UID = 3, Name = "Bangladesh", Code = "BAN", Continent = "Asia" });
            modelBuilder.Entity<Country>().HasData(new Country() { UID = 4, Name = "Sri Lanka", Code = "SRL", Continent = "Asia" });
            modelBuilder.Entity<Country>().HasData(new Country() { UID = 5, Name = "Pakistan", Code = "PAK", Continent = "Asia" });
            modelBuilder.Entity<Country>().HasData(new Country() { UID = 6, Name = "China", Code = "CNA", Continent = "Asia" });
            modelBuilder.Entity<Country>().HasData(new Country() { UID = 7, Name = "France", Code = "FRA", Continent = "Europe" });

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().HasKey(u => u.UID);
            modelBuilder.Entity<User>(entity => entity.HasOne(p => p.Role));

            modelBuilder.Entity<University>().ToTable("University");
            modelBuilder.Entity<University>().HasKey(u => u.UID);
            modelBuilder.Entity<University>().HasData(new University() { });

            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Student>().HasKey(s => s.ProfileUID);
            modelBuilder.Entity<Student>().HasOne(s => s.User).WithOne().HasForeignKey<Student>(s => s.UserUID);
            //Note:- the implementation of 'HasForeignKey("")' with string parameter is normally used with shadow foreign keys.So dont 
            //what will be the impact used with properly defined foreign key.
            modelBuilder.Entity<Student>().HasOne(s => s.University).WithOne().HasForeignKey<Student>(s => s.UniversityUID);

            modelBuilder.Entity<Landlord>().ToTable("Landlord");
            modelBuilder.Entity<Landlord>().HasKey(l=>l.ProfileUID);
            modelBuilder.Entity<Landlord>().HasOne(s=>s.User).WithOne().HasForeignKey<Landlord>(s => s.UserUID);

            modelBuilder.Entity<ImageFile>().ToTable("ImageFile");
            modelBuilder.Entity<ImageFile>().HasKey(i => i.UID);

            modelBuilder.Entity<Property>().ToTable("Property");
            modelBuilder.Entity<Property>().HasKey(p => p.UID);
            modelBuilder.Entity<Property>().HasOne(p=>p.Landlord).WithOne().HasForeignKey<Property>(p => p.LandlordProfileUID);

            modelBuilder.Entity<PropertyImage>().ToTable("PropertyImage");
            modelBuilder.Entity<PropertyImage>().HasKey(pi => pi.UID);
            modelBuilder.Entity<PropertyImage>().HasOne(p => p.ImageFile).WithOne().HasForeignKey<PropertyImage>(p => p.ImageFileUID);
            modelBuilder.Entity<PropertyImage>().HasOne<Property>().WithMany(p => p.Images).HasForeignKey(pi => pi.PropertyUID);

            modelBuilder.Entity<PropertyImage>().ToTable("PropertyImage");
            modelBuilder.Entity<PropertyImage>().HasKey(pi => pi.UID);
            modelBuilder.Entity<PropertyImage>().HasOne(p=>p.ImageFile).WithOne().HasForeignKey<PropertyImage>(p => p.ImageFileUID);
            modelBuilder.Entity<PropertyImage>().HasOne<Property>().WithMany(p=>p.Images).HasForeignKey(pi=>pi.PropertyUID);

            modelBuilder.Entity<PropertyListing>().ToTable("PropertyListing");
            modelBuilder.Entity<PropertyListing>().HasKey(pl => pl.UID);
            modelBuilder.Entity<PropertyListing>().HasOne(pl=>pl.Property).WithMany(p => p.Listings).HasForeignKey(pl => pl.PropertyUID);

            modelBuilder.Entity<PropertyViewing>().ToTable("PropertyViewing");
            modelBuilder.Entity<PropertyViewing>().HasKey(pv => pv.UID);
            modelBuilder.Entity<PropertyViewing>().HasOne<PropertyListing>().WithMany(pl => pl.Viewings).HasForeignKey(pv => pv.PropertyListingUID);

            modelBuilder.Entity<PropertyRenting>().ToTable("PropertyRenting");
            modelBuilder.Entity<PropertyRenting>().HasKey(pr => pr.UID);
            modelBuilder.Entity<PropertyRenting>().HasOne<PropertyListing>().WithMany(pl => pl.Rentings).HasForeignKey(pr => pr.PropertyListingUID);

            modelBuilder.Entity<PropertyReview>().ToTable("PropertyReview");
            modelBuilder.Entity<PropertyReview>().HasKey(pr => pr.UID);
            modelBuilder.Entity<PropertyReview>().HasOne<Property>().WithMany(p => p.Reviews).HasForeignKey(pr => pr.PropertyUID);

        }

        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<FurnishmentType> FurnishmentTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }

        public DbSet<Student> Students { get; set; }               
        public DbSet<User> Users { get; set; }       
        public DbSet<Landlord> Landlords { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }
        public DbSet<Property> Properties { get; set; } 
        public DbSet<PropertyAttribute> PropertyAttributes { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }   
        public DbSet<PropertyListing> PropertyListings { get; set; }
        public DbSet<PropertyListingAttribute> PropertyListingAttributes { get; set; }
        public DbSet<PropertyViewing> PropertyViewings { get; set; }   
        public DbSet<PropertyRenting> PropertyRentings { get; set; }   
        public DbSet<PropertyReview> PropertyReviews { get; set; }   
    }
}
