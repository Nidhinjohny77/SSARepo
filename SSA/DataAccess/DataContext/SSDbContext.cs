﻿

using System.Globalization;

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
            //Master Table #1
            modelBuilder.Entity<PropertyType>().ToTable("PropertyType");
            modelBuilder.Entity<PropertyType>().HasKey(pt => pt.UID);
            modelBuilder.Entity<PropertyType>().HasData(new PropertyType() { UID = 1, Code = "FLT", Description="Flat" });
            modelBuilder.Entity<PropertyType>().HasData(new PropertyType() { UID = 2, Code = "HSTL", Description = "Hostel" });
            modelBuilder.Entity<PropertyType>().HasData(new PropertyType() { UID = 3, Code = "PG", Description = "Paying Guest" });
            modelBuilder.Entity<PropertyType>().HasData(new PropertyType() { UID = 4, Code = "HSO", Description = "House in Single Occupancy" });
            modelBuilder.Entity<PropertyType>().HasData(new PropertyType() { UID = 5, Code = "HMO", Description = "House in Multiple Occupancy" });

            //Master Table #2
            modelBuilder.Entity<FurnishType>().ToTable("FurnishType");
            modelBuilder.Entity<FurnishType>().HasKey(ft => ft.UID);
            modelBuilder.Entity<FurnishType>().HasData(new FurnishType() { UID = 1, Code = "FULL", Description = "Fully Furnished" });
            modelBuilder.Entity<FurnishType>().HasData(new FurnishType() { UID = 2, Code = "SEMI", Description = "Semi Furnished" });
            modelBuilder.Entity<FurnishType>().HasData(new FurnishType() { UID = 3, Code = "NF", Description = "Non Furnished" });

            //Master Table #3
            modelBuilder.Entity<ItemType>().ToTable("ItemType");
            modelBuilder.Entity<ItemType>().HasKey(ft => ft.UID);
            modelBuilder.Entity<ItemType>().HasData(new ItemType() { UID = 1, Name = "Furniture", Description = "Furnitures available." });
            modelBuilder.Entity<ItemType>().HasData(new ItemType() { UID = 2, Name = "Electrical", Description = "Electrical items available." });
            modelBuilder.Entity<ItemType>().HasData(new ItemType() { UID = 3, Name = "Gas Equipment", Description = "Equipments to deal the cooking gas." });
            modelBuilder.Entity<ItemType>().HasData(new ItemType() { UID = 4, Name = "Kitchen", Description = "Kitchen utensils,sink." });
            modelBuilder.Entity<ItemType>().HasData(new ItemType() { UID = 5, Name = "Bathroom Fittings", Description = "Bathroom fittings." });
            modelBuilder.Entity<ItemType>().HasData(new ItemType() { UID = 6, Name = "Heat Fittings", Description = "Heating fittings." });

            //Master Table #4
            modelBuilder.Entity<Item>().ToTable("Item");
            modelBuilder.Entity<Item>().HasKey(it => it.UID);
            modelBuilder.Entity<Item>().HasOne(it => it.ItemType).WithMany().HasForeignKey(it => it.ItemTypeUID);
            modelBuilder.Entity<Item>().HasData(new Item() { UID=1, Name="Study Chair",ItemTypeUID=1});
            modelBuilder.Entity<Item>().HasData(new Item() { UID = 2, Name = "Study Table", ItemTypeUID = 1 });
            modelBuilder.Entity<Item>().HasData(new Item() { UID = 3, Name = "Dining Table", ItemTypeUID = 1 });
            modelBuilder.Entity<Item>().HasData(new Item() { UID = 4, Name = "Dining Chair", ItemTypeUID = 1 });
            modelBuilder.Entity<Item>().HasData(new Item() { UID = 5, Name = "Couch", ItemTypeUID = 1 });
            modelBuilder.Entity<Item>().HasData(new Item() { UID = 6, Name = "Bed", ItemTypeUID = 1 });
            modelBuilder.Entity<Item>().HasData(new Item() { UID = 7, Name = "Cot", ItemTypeUID = 1 });
            modelBuilder.Entity<Item>().HasData(new Item() { UID = 8, Name = "TV Table", ItemTypeUID = 1 });
            modelBuilder.Entity<Item>().HasData(new Item() { UID = 9, Name = "Cup Board", ItemTypeUID = 1 });
            modelBuilder.Entity<Item>().HasData(new Item() { UID = 10, Name = "Bulb", ItemTypeUID = 2 });
            modelBuilder.Entity<Item>().HasData(new Item() { UID = 11, Name = "Electric Kettle", ItemTypeUID = 2 });
            modelBuilder.Entity<Item>().HasData(new Item() { UID = 12, Name = "Electric Hob", ItemTypeUID = 2 });
            modelBuilder.Entity<Item>().HasData(new Item() { UID = 13, Name = "Electric Oven", ItemTypeUID = 2 });
            modelBuilder.Entity<Item>().HasData(new Item() { UID = 14, Name = "Washing Machine", ItemTypeUID = 2 });
            modelBuilder.Entity<Item>().HasData(new Item() { UID = 15, Name = "Microwave", ItemTypeUID = 2 });
            modelBuilder.Entity<Item>().HasData(new Item() { UID = 16, Name = "Cooker", ItemTypeUID = 3 });
            modelBuilder.Entity<Item>().HasData(new Item() { UID = 17, Name = "Boiler", ItemTypeUID = 6 });
            modelBuilder.Entity<Item>().HasData(new Item() { UID = 18, Name = "Radiator", ItemTypeUID = 6 });
            modelBuilder.Entity<Item>().HasData(new Item() { UID = 19, Name = "Wash Sink", ItemTypeUID = 5 });
            modelBuilder.Entity<Item>().HasData(new Item() { UID = 20, Name = "Bath Tub", ItemTypeUID = 5 });
            modelBuilder.Entity<Item>().HasData(new Item() { UID = 21, Name = "Closet", ItemTypeUID = 5 });

            //Master Table #5
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Role>().HasKey(r=>r.UID);
            modelBuilder.Entity<Role>().HasData(new Role() { UID = 1, Name = "Admin" });
            modelBuilder.Entity<Role>().HasData(new Role() { UID =2, Name = "Student" });
            modelBuilder.Entity<Role>().HasData(new Role() { UID = 3, Name = "Landlord" });
            modelBuilder.Entity<Role>().HasData(new Role() { UID = 4, Name = "University" });
            modelBuilder.Entity<Role>().HasData(new Role() { UID = 5, Name = "Consultant" });

            //Master Table #6
            modelBuilder.Entity<TenancyType>().ToTable("TenancyType");
            modelBuilder.Entity<TenancyType>().HasKey(tt => tt.UID);
            modelBuilder.Entity<TenancyType>().HasData(new TenancyType() { UID = 1, Description = "Student Bachelor" });
            modelBuilder.Entity<TenancyType>().HasData(new TenancyType() { UID = 2, Description = "Student Married Couple" });
            modelBuilder.Entity<TenancyType>().HasData(new TenancyType() { UID = 3, Description = "Student UnMarried Couple" });
            modelBuilder.Entity<TenancyType>().HasData(new TenancyType() { UID = 4, Description = "Student Married Couple With Children" });
            modelBuilder.Entity<TenancyType>().HasData(new TenancyType() { UID = 5, Description = "Student UnMarried Couple With Children" });
            modelBuilder.Entity<TenancyType>().HasData(new TenancyType() { UID = 6, Description = "Married Couple" });
            modelBuilder.Entity<TenancyType>().HasData(new TenancyType() { UID = 7, Description = "UnMarried Couple" });
            modelBuilder.Entity<TenancyType>().HasData(new TenancyType() { UID = 8, Description = "Married Couple With Children" });
            modelBuilder.Entity<TenancyType>().HasData(new TenancyType() { UID = 9, Description = "UnMarried Couple With Children" });
            modelBuilder.Entity<TenancyType>().HasData(new TenancyType() { UID = 10, Description = "Any" });

            //Master Table #7
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<Country>().HasKey(c => c.UID);
            modelBuilder.Entity<Country>().HasOne(c => c.Currency).WithMany().HasForeignKey(c => c.CurrencyUID);
            modelBuilder.Entity<Country>().HasData(new Country() { UID = 1, Name = "United Kingdom",Code="UK",Continent="Europe",CurrencyUID=2 });
            modelBuilder.Entity<Country>().HasData(new Country() { UID = 2, Name = "India", Code = "IND", Continent = "Asia", CurrencyUID = 1 });
            modelBuilder.Entity<Country>().HasData(new Country() { UID = 3, Name = "Bangladesh", Code = "BAN", Continent = "Asia", CurrencyUID = 3 });
            modelBuilder.Entity<Country>().HasData(new Country() { UID = 4, Name = "Sri Lanka", Code = "SRL", Continent = "Asia", CurrencyUID = 4 });
            modelBuilder.Entity<Country>().HasData(new Country() { UID = 5, Name = "Pakistan", Code = "PAK", Continent = "Asia", CurrencyUID = 5 });
            modelBuilder.Entity<Country>().HasData(new Country() { UID = 6, Name = "China", Code = "CNA", Continent = "Asia", CurrencyUID = 6 });
            modelBuilder.Entity<Country>().HasData(new Country() { UID = 7, Name = "France", Code = "FRA", Continent = "Europe", CurrencyUID = 7 });

            //Master Table #8
            modelBuilder.Entity<Currency>().ToTable("Currency");
            modelBuilder.Entity<Currency>().HasKey(cu=>cu.UID);           
            modelBuilder.Entity<Currency>().HasData(new Currency() { UID=1,Name="Rupee",Code="INR",Symbol=""});
            modelBuilder.Entity<Currency>().HasData(new Currency() { UID = 2, Name = "Pound", Code = "GBP", Symbol = "" });
            modelBuilder.Entity<Currency>().HasData(new Currency() { UID = 3, Name = "Bangladeshi Taka", Code = "BDT", Symbol = "" });
            modelBuilder.Entity<Currency>().HasData(new Currency() { UID = 4, Name = "Sri Lankan Rupee", Code = "LKR", Symbol = ""});
            modelBuilder.Entity<Currency>().HasData(new Currency() { UID = 5, Name = "Pakistani Rupee", Code = "PKR", Symbol = ""});
            modelBuilder.Entity<Currency>().HasData(new Currency() { UID = 6, Name = "Chinese Yuan", Code = "CNY", Symbol = ""});
            modelBuilder.Entity<Currency>().HasData(new Currency() { UID = 7, Name = "Euro", Code = "EUR", Symbol = ""});

            //Master Table #9
            modelBuilder.Entity<University>().ToTable("University");
            modelBuilder.Entity<University>().HasKey(u => u.UID);
            modelBuilder.Entity<University>().HasOne(u => u.Country).WithMany().HasForeignKey(u => u.CountryUID);
            modelBuilder.Entity<University>().HasData(new University() 
            {   UID=1,
                Name="Teeside University",
                Address="Tees Valley,Middlesbrough,England", 
                UniversityCode="UNITEES",
                ContactNumber="7464647464",
                ContactEmail="tees.uni@gmail.com",
                CountryUID=1,
                IsActive=true,
                Ratings=3
            });
            modelBuilder.Entity<University>().HasData(new University()
            {
                UID = 2,
                Name = "University of Edinburgh",
                Address = "Ediburgh,Scotland",
                UniversityCode = "UNIEDIN",
                ContactNumber = "7334647464",
                ContactEmail = "universityofedinburgh.uni@gmail.com",
                CountryUID = 1,
                IsActive = true,
                Ratings = 5
            });

            //Master Table #10
            modelBuilder.Entity<ImageType>().ToTable("ImageType");
            modelBuilder.Entity<ImageType>().HasKey(it => it.UID);
            modelBuilder.Entity<ImageType>().HasData(new ImageType() { UID = 1, Name = "ThumbNail" });
            modelBuilder.Entity<ImageType>().HasData(new ImageType() { UID = 2, Name = "Full" });

            //Master Table #11
            modelBuilder.Entity<FileType>().ToTable("FileType");
            modelBuilder.Entity<FileType>().HasKey(ift => ift.UID);
            modelBuilder.Entity<FileType>().HasData(new FileType() { UID = 1, Name = "jpeg",Description="this type is used for storing images." });


            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().HasKey(u => u.UID);
            modelBuilder.Entity<User>(entity => entity.HasOne(p => p.Role));
            

            modelBuilder.Entity<Tenant>().ToTable("Tenant");
            modelBuilder.Entity<Tenant>().HasKey(t=>t.UID);
            modelBuilder.Entity<Tenant>().HasOne(t=>t.User).WithOne().HasForeignKey<Tenant>(t => t.UserUID);
            modelBuilder.Entity<Tenant>().HasOne(t => t.Country).WithOne().HasForeignKey<Tenant>(t => t.CountryUID);
            modelBuilder.Entity<Tenant>().HasOne(t => t.TenancyType).WithOne().HasForeignKey<Tenant>(t => t.TenancyTypeUID);

            modelBuilder.Entity<TenantPreference>().ToTable("TenantPreference");
            modelBuilder.Entity<TenantPreference>().HasKey(tr => tr.UID);
            modelBuilder.Entity<TenantPreference>().HasOne(tr => tr.Tenant).WithOne().HasForeignKey<TenantPreference>(tr => tr.TenantUID);
            modelBuilder.Entity<TenantPreference>().HasOne(tr => tr.PropertyType).WithOne().HasForeignKey<TenantPreference>(tr => tr.PropertyTypeUID);
            modelBuilder.Entity<TenantPreference>().HasOne(tr => tr.FurnishType).WithOne().HasForeignKey<TenantPreference>(tr => tr.FurnishTypeUID);
            modelBuilder.Entity<TenantPreference>().Property(tp=>tp.PreferedTenancyTypeUID).IsRequired(false);
            modelBuilder.Entity<TenantPreference>().Property(tp => tp.PreferedBedRoomCount).IsRequired(false);
            modelBuilder.Entity<TenantPreference>().Property(tp => tp.PreferedBathRoomCount).IsRequired(false);
            modelBuilder.Entity<TenantPreference>().Property(tp => tp.PreferedOccupantCount).IsRequired(false);
            modelBuilder.Entity<TenantPreference>().Property(tp => tp.IsSharingPrefered).IsRequired(false);
            modelBuilder.Entity<TenantPreference>().Property(tp => tp.IsAttachedBathroomPrefered).IsRequired(false);
            modelBuilder.Entity<TenantPreference>().Property(tp => tp.IsRentIncludingBillsPrefered).IsRequired(false);
            modelBuilder.Entity<TenantPreference>().Property(tp => tp.PreferedTenancyPeriodInMonths).IsRequired(false);
            modelBuilder.Entity<TenantPreference>().Property(tp => tp.StartRangeAmount).IsRequired(false);
            modelBuilder.Entity<TenantPreference>().Property(tp => tp.EndRangeAmount).IsRequired(false);

            modelBuilder.Entity<StudentProfile>().ToTable("StudentProfile");
            modelBuilder.Entity<StudentProfile>().HasKey(s => s.UID);
            modelBuilder.Entity<StudentProfile>().HasOne(s => s.Tenant).WithOne().HasForeignKey<StudentProfile>(s => s.TenantUID);
            //Note:- the implementation of 'HasForeignKey("")' with string parameter is normally used with shadow foreign keys.So dont 
            //what will be the impact used with properly defined foreign key.
            modelBuilder.Entity<StudentProfile>().HasOne(s => s.University).WithOne().HasForeignKey<StudentProfile>(s => s.UniversityUID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Landlord>().ToTable("Landlord");
            modelBuilder.Entity<Landlord>().HasKey(l=>l.UID);
            modelBuilder.Entity<Landlord>().HasOne(s=>s.User).WithOne().HasForeignKey<Landlord>(s => s.UserUID);
            modelBuilder.Entity<Landlord>().HasOne(s => s.Country).WithMany().HasForeignKey(s => s.CountryUID).OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Property>().ToTable("Property");
            modelBuilder.Entity<Property>().HasKey(p => p.UID);
            modelBuilder.Entity<Property>().HasOne(p=>p.Landlord).WithMany().HasForeignKey(p => p.LandlordUID);
            modelBuilder.Entity<Property>().HasOne(p => p.Country).WithMany().HasForeignKey(p => p.CountryUID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PropertyAttribute>().ToTable("PropertyAttribute");
            modelBuilder.Entity<PropertyAttribute>().HasKey(pa=>pa.UID);
            modelBuilder.Entity<PropertyAttribute>().HasOne(pa => pa.Property).WithOne(p => p.PropertyAttribute).HasForeignKey<PropertyAttribute>(pa => pa.PropertyUID);
            modelBuilder.Entity<PropertyAttribute>().HasOne(pa=>pa.PropertyType).WithMany().HasForeignKey(pa=>pa.PropertyTypeUID);
            //modelBuilder.Entity<PropertyAttribute>().HasOne(pa=>pa.FurnishType).WithMany().HasForeignKey(pa => pa.FurnishTypeUID);
            //modelBuilder.Entity<PropertyAttribute>().Property(pa => pa.FurnishType).IsRequired(false);
            modelBuilder.Entity<PropertyAttribute>().Property(pa=>pa.TotalAreaInSqFT).IsRequired(false);
            modelBuilder.Entity<PropertyAttribute>().Property(pa => pa.ParkingSlotCount).IsRequired(false);

            modelBuilder.Entity<PropertyImage>().ToTable("PropertyImage");
            modelBuilder.Entity<PropertyImage>().HasKey(pi => pi.UID);
            modelBuilder.Entity<PropertyImage>().HasOne(pi => pi.ImageType).WithMany().HasForeignKey(pi => pi.ImageTypeUID);
            modelBuilder.Entity<PropertyImage>().HasOne(pi => pi.FileType).WithMany().HasForeignKey(pi => pi.FileTypeUID);
            modelBuilder.Entity<PropertyImage>().HasOne(pi=>pi.Property).WithMany(p => p.Images).HasForeignKey(pi => pi.PropertyUID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PropertyListing>().ToTable("PropertyListing");
            modelBuilder.Entity<PropertyListing>().HasKey(pl => pl.UID);
            modelBuilder.Entity<PropertyListing>().HasOne(pl=>pl.Property).WithMany(p => p.Listings).HasForeignKey(pl => pl.PropertyUID);

            modelBuilder.Entity<PropertyListingAttribute>().ToTable("PropertyListingAttribute");
            modelBuilder.Entity<PropertyListingAttribute>().HasKey(pla => pla.UID);
            modelBuilder.Entity<PropertyListingAttribute>().HasOne(pla => pla.TenancyType).WithOne()
                                                            .HasForeignKey<PropertyListingAttribute>(pla => pla.TenancyTypeUID);
            modelBuilder.Entity<PropertyListingAttribute>().HasOne(pla => pla.PropertyListing).WithOne(pl=>pl.PropertyListingAttribute)
                                                            .HasForeignKey<PropertyListingAttribute>(pla => pla.PropertyListingUID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PropertyListingAttribute>().HasOne(pla => pla.PropertyAttribute).WithMany()
                                                            .HasForeignKey(pla => pla.PropertyAttributeUID);
            modelBuilder.Entity<PropertyListingAttribute>().Property(pla => pla.AvailableParkingSlots).IsRequired(false);


            modelBuilder.Entity<PropertyViewing>().ToTable("PropertyViewing");
            modelBuilder.Entity<PropertyViewing>().HasKey(pv => pv.UID);
            modelBuilder.Entity<PropertyViewing>().HasOne(pv=>pv.PropertyListing).WithMany(pl => pl.Viewings).HasForeignKey(pv => pv.PropertyListingUID);
            modelBuilder.Entity<PropertyViewing>().HasOne(pv=>pv.Tenant).WithMany(t=>t.Viewings).HasForeignKey(pv => pv.TenantUID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PropertyRenting>().ToTable("PropertyRenting");
            modelBuilder.Entity<PropertyRenting>().HasKey(pr => pr.UID);
            modelBuilder.Entity<PropertyRenting>().HasOne(pr=>pr.PropertyListing).WithMany(pl => pl.Rentings).HasForeignKey(pr => pr.PropertyListingUID);
            modelBuilder.Entity<PropertyRenting>().HasOne(pr => pr.Tenant).WithMany().HasForeignKey(pr => pr.TenantUID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TenantItem>().ToTable("TenantItem");
            modelBuilder.Entity<TenantItem>().HasKey(cti => cti.UID);
            modelBuilder.Entity<TenantItem>().HasOne(cti=>cti.PropertyRenting).WithMany().HasForeignKey(cti => cti.PropertyRentingUID);
            modelBuilder.Entity<TenantItem>().HasOne(cti => cti.Item).WithOne().HasForeignKey<TenantItem>(cti => cti.ItemUID);
            modelBuilder.Entity<TenantItem>().HasOne(cti => cti.Currency).WithOne().HasForeignKey<TenantItem>(cti => cti.CurrencyUID);

            modelBuilder.Entity<PropertyReview>().ToTable("PropertyReview");
            modelBuilder.Entity<PropertyReview>().HasKey(pr => pr.UID);
            modelBuilder.Entity<PropertyReview>().HasOne<Property>().WithMany(p => p.Reviews).HasForeignKey(pr => pr.PropertyUID);

            PopulateStudentData(modelBuilder);
            PopulateLandlordData(modelBuilder);

        }

        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<FurnishType> FurnishTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<TenancyType> TenantTypes { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<TenantPreference> TenantPreferences { get; set; }
        
        public DbSet<StudentProfile> Students { get; set; }
        public DbSet<Landlord> Landlords { get; set; }

        public DbSet<ImageType> ImageTypes { get; set; }
        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<Property> Properties { get; set; } 
        public DbSet<PropertyAttribute> PropertyAttributes { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }   
        public DbSet<PropertyListing> PropertyListings { get; set; }
        public DbSet<PropertyListingAttribute> PropertyListingAttributes { get; set; }
        public DbSet<PropertyViewing> PropertyViewings { get; set; }   
        public DbSet<PropertyRenting> PropertyRentings { get; set; }   
        public DbSet<PropertyReview> PropertyReviews { get; set; }


        private void PopulateLandlordData(ModelBuilder modelBuilder)
        {
            var culture = CultureInfo.GetCultureInfo("en-GB");
            var uniqueUID = Guid.NewGuid().ToString();
            var user1 = new User()
            {
                UID = uniqueUID,
                FirstName = "Nora",
                LastName = "Tom",
                UserName = "nora",
                Password = "rege",
                UserType = 0,
                Email = "nora.sde@gmail.com",
                IsActive = true,
                RoleUID = 3,
                CreatedBy = uniqueUID,
                LastUpdatedBy = uniqueUID,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now
            };
            var landlord1 = new Landlord()
            {
                UID = Guid.NewGuid().ToString(),
                UserUID = uniqueUID,
                Address = "46,Lothian Road, Middlesborough",
                CountryUID = 1,
                DOB = Convert.ToDateTime("26/07/1988", culture.DateTimeFormat),
                PhoneNumber="07773636363",
                IsActive=true,
                CreatedBy= uniqueUID,
                LastUpdatedBy= uniqueUID,
                CreatedDate= DateTime.Now,
                LastUpdatedDate= DateTime.Now
            };
            modelBuilder.Entity<User>().HasData(user1);
            modelBuilder.Entity<Landlord>().HasData(landlord1);

            var uniqueUID1 = Guid.NewGuid().ToString();
            var user2 = new User()
            {
                UID = uniqueUID1,
                FirstName = "Renjith",
                LastName = "M",
                UserName = "renjith",
                Password = "rege",
                UserType = 0,
                Email = "renjith.sde@gmail.com",
                IsActive = true,
                RoleUID = 3,
                CreatedBy = uniqueUID1,
                LastUpdatedBy = uniqueUID1,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now
            };
            var landlord2 = new Landlord()
            {
                UID = Guid.NewGuid().ToString(),
                UserUID = user2.UID,
                Address = "34,Parliament Road, Middlesborough",
                CountryUID = 1,
                DOB = Convert.ToDateTime("26/07/1994", culture.DateTimeFormat),
                PhoneNumber = "07773636363",
                IsActive = true,
                CreatedBy = user2.UID,
                LastUpdatedBy = user2.UID,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now
            };
            modelBuilder.Entity<User>().HasData(user2);
            modelBuilder.Entity<Landlord>().HasData(landlord2);

            var p1 = new Property()
            {
                UID = Guid.NewGuid().ToString(),
                LandlordUID = landlord2.UID,
                Name = "House 1",
                PostCode = "TS1 2HR",
                Address = "Oxford Street, Middlesbrough TS1",
                CountryUID = 1,
                IsActive = true,
                CreatedBy = user2.UID,
                LastUpdatedBy = user2.UID,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now
            };
            var pa1 = new PropertyAttribute()
            {
                UID = Guid.NewGuid().ToString(),
                PropertyUID = p1.UID,
                PropertyTypeUID = 5,
                FurnishTypeUID = 1,
                BedroomCount = 4,
                BathroomCount = 2,
                FloorCount = 2,
                MaxOccupantCount = 5,
                ParkingSlotCount = 2,
                TotalAreaInSqFT = 1200,
                IsGarageAvailable = true,
                IsParkingSlotAvailable = true,
                IsBackyardAvailable = true,
                IsActive = true,
                CreatedBy = user2.UID,
                LastUpdatedBy = user2.UID,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now
            };
            var pl1 = new PropertyListing()
            {
                UID = Guid.NewGuid().ToString(),
                PropertyUID = p1.UID,
                ListedByUser = user2.UID,
                ListingDate = DateTime.Now,
                Description= "4 bed terraced house to rent",
                ListingAmount = 2850,
                IsCTIAvailableForSale = false,
                IsActive=true,
                CreatedBy = user2.UID,
                LastUpdatedBy = user2.UID,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now
            };
            var pla1 = new PropertyListingAttribute()
            {
                UID = Guid.NewGuid().ToString(),
                PropertyAttributeUID = pa1.UID,
                PropertyListingUID = pl1.UID,
                TenancyTypeUID = 10,
                Landmark = "0.5 miles Middlesbrough",
                AllowedOccupantCount = 5,
                AvailableBedroomCount = 4,
                AvailableBathroomCount = 2,
                AvailableParkingSlots = 2,
                IsNew=true,
                IsStudentFriendly=true,
                IsChildrenAllowed = true,
                IsParkingAvailable = true,
                IsPartyingAllowed = true,
                IsSharingAllowed = true,
                IsPetsAllowed = true,
                IsSmokingAllowed = true,
                IsUnisex = true,
                IsActive = true,
                CreatedBy = user2.UID,
                LastUpdatedBy = user2.UID,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now
            };
            modelBuilder.Entity<Property>().HasData(p1);
            modelBuilder.Entity<PropertyAttribute>().HasData(pa1);
            modelBuilder.Entity<PropertyListing>().HasData(pl1);
            modelBuilder.Entity<PropertyListingAttribute>().HasData(pla1);



            var p2 = new Property()
            {
                UID = Guid.NewGuid().ToString(),
                LandlordUID = landlord2.UID,
                Name = "House 2",
                PostCode = "TS2 2HR",
                Address = "Kings Street, Middlesbrough TS2",
                CountryUID = 1,
                IsActive = true,
                CreatedBy = user2.UID,
                LastUpdatedBy = user2.UID,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now
            };
            var pa2 = new PropertyAttribute()
            {
                UID = Guid.NewGuid().ToString(),
                PropertyUID = p2.UID,
                PropertyTypeUID = 5,
                FurnishTypeUID = 1,
                BedroomCount = 2,
                BathroomCount = 2,
                FloorCount = 1,
                MaxOccupantCount = 3,
                ParkingSlotCount = 1,
                TotalAreaInSqFT = 700,
                IsGarageAvailable = true,
                IsParkingSlotAvailable = true,
                IsBackyardAvailable = true,
                IsActive = true,
                CreatedBy = user2.UID,
                LastUpdatedBy = user2.UID,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now
            };
            var pl2 = new PropertyListing()
            {
                UID = Guid.NewGuid().ToString(),
                PropertyUID = p2.UID,
                ListedByUser = user2.UID,
                ListingDate = DateTime.Now,
                Description = "2 BHK house to rent",
                ListingAmount = 1350,
                IsCTIAvailableForSale = false,
                IsActive = true,
                CreatedBy = user2.UID,
                LastUpdatedBy = user2.UID,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now
            };
            var pla2 = new PropertyListingAttribute()
            {
                UID = Guid.NewGuid().ToString(),
                PropertyAttributeUID = pa2.UID,
                PropertyListingUID = pl2.UID,
                TenancyTypeUID = 10,
                Landmark = "0.5 miles Middlesbrough",
                AllowedOccupantCount = 3,
                AvailableBedroomCount = 2,
                AvailableBathroomCount = 2,
                AvailableParkingSlots = 1,
                IsNew=false,
                IsStudentFriendly=true,
                IsChildrenAllowed = true,
                IsParkingAvailable = true,
                IsPartyingAllowed = true,
                IsSharingAllowed = true,
                IsPetsAllowed = true,
                IsSmokingAllowed = true,
                IsUnisex = true,
                IsActive = true,
                CreatedBy = user2.UID,
                LastUpdatedBy = user2.UID,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now
            };
            modelBuilder.Entity<Property>().HasData(p2);
            modelBuilder.Entity<PropertyAttribute>().HasData(pa2);
            modelBuilder.Entity<PropertyListing>().HasData(pl2);
            modelBuilder.Entity<PropertyListingAttribute>().HasData(pla2);

            var p3 = new Property()
            {
                UID = Guid.NewGuid().ToString(),
                LandlordUID = landlord2.UID,
                Name = "House 3",
                PostCode = "TS3 2HR",
                Address = "Numens Street, Middlesbrough TS3",
                CountryUID = 1,
                IsActive = true,
                CreatedBy = user2.UID,
                LastUpdatedBy = user2.UID,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now
            };
            var pa3 = new PropertyAttribute()
            {
                UID = Guid.NewGuid().ToString(),
                PropertyUID = p3.UID,
                PropertyTypeUID = 5,
                FurnishTypeUID = 1,
                BedroomCount = 1,
                BathroomCount = 1,
                FloorCount = 1,
                MaxOccupantCount = 2,
                ParkingSlotCount = 1,
                TotalAreaInSqFT = 600,
                IsGarageAvailable = true,
                IsParkingSlotAvailable = true,
                IsBackyardAvailable = true,
                IsActive = true,
                CreatedBy = user2.UID,
                LastUpdatedBy = user2.UID,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now
            };
            var pl3 = new PropertyListing()
            {
                UID = Guid.NewGuid().ToString(),
                PropertyUID = p3.UID,
                ListedByUser = user2.UID,
                ListingDate = DateTime.Now,
                Description = "1 BHK Appartmet to rent",
                ListingAmount = 1250,
                IsCTIAvailableForSale = false,
                IsActive = true,
                CreatedBy = user2.UID,
                LastUpdatedBy = user2.UID,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now
            };
            var pla3 = new PropertyListingAttribute()
            {
                UID = Guid.NewGuid().ToString(),
                PropertyAttributeUID = pa3.UID,
                PropertyListingUID = pl3.UID,
                TenancyTypeUID = 10,
                Landmark = "0.5 miles Middlesbrough",
                AllowedOccupantCount = 2,
                AvailableBedroomCount = 1,
                AvailableBathroomCount = 1,
                AvailableParkingSlots = 1,
                IsNew = false,
                IsStudentFriendly = true,
                IsChildrenAllowed = true,
                IsParkingAvailable = true,
                IsPartyingAllowed = true,
                IsSharingAllowed = true,
                IsPetsAllowed = true,
                IsSmokingAllowed = true,
                IsUnisex = true,
                IsActive = true,
                CreatedBy = user2.UID,
                LastUpdatedBy = user2.UID,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now
            };
            modelBuilder.Entity<Property>().HasData(p3);
            modelBuilder.Entity<PropertyAttribute>().HasData(pa3);
            modelBuilder.Entity<PropertyListing>().HasData(pl3);
            modelBuilder.Entity<PropertyListingAttribute>().HasData(pla3);

            var p4 = new Property()
            {
                UID = Guid.NewGuid().ToString(),
                LandlordUID = landlord2.UID,
                Name = "House 4",
                PostCode = "DS4 2HR",
                Address = "Edward Pease Way, West Park Garden Village, Darlington",
                CountryUID = 1,
                IsActive = true,
                CreatedBy = user2.UID,
                LastUpdatedBy = user2.UID,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now
            };
            var pa4 = new PropertyAttribute()
            {
                UID = Guid.NewGuid().ToString(),
                PropertyUID = p4.UID,
                PropertyTypeUID = 5,
                FurnishTypeUID = 1,
                BedroomCount = 6,
                BathroomCount = 3,
                FloorCount = 3,
                MaxOccupantCount = 12,
                ParkingSlotCount = 3,
                TotalAreaInSqFT = 2600,
                IsGarageAvailable = true,
                IsParkingSlotAvailable = true,
                IsBackyardAvailable = true,
                IsActive = true,
                CreatedBy = user2.UID,
                LastUpdatedBy = user2.UID,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now
            };
            var pl4 = new PropertyListing()
            {
                UID = Guid.NewGuid().ToString(),
                PropertyUID = p4.UID,
                ListedByUser = user2.UID,
                ListingDate = DateTime.Now,
                Description = "The Orchard at West Park",
                ListingAmount = 2950,
                IsCTIAvailableForSale = false,
                IsActive = true,
                CreatedBy = user2.UID,
                LastUpdatedBy = user2.UID,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now
            };
            var pla4 = new PropertyListingAttribute()
            {
                UID = Guid.NewGuid().ToString(),
                PropertyAttributeUID = pa4.UID,
                PropertyListingUID = pl4.UID,
                TenancyTypeUID = 10,
                Landmark = "0.5 miles Middlesbrough",
                AllowedOccupantCount = 12,
                AvailableBedroomCount = 6,
                AvailableBathroomCount = 3,
                AvailableParkingSlots = 3,
                IsNew = true,
                IsStudentFriendly = false,
                IsChildrenAllowed = true,
                IsParkingAvailable = true,
                IsPartyingAllowed = true,
                IsSharingAllowed = true,
                IsPetsAllowed = true,
                IsSmokingAllowed = true,
                IsUnisex = true,
                IsActive = true,
                CreatedBy = user2.UID,
                LastUpdatedBy = user2.UID,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now
            };
            modelBuilder.Entity<Property>().HasData(p4);
            modelBuilder.Entity<PropertyAttribute>().HasData(pa4);
            modelBuilder.Entity<PropertyListing>().HasData(pl4);
            modelBuilder.Entity<PropertyListingAttribute>().HasData(pla4);

            var p5 = new Property()
            {
                UID = Guid.NewGuid().ToString(),
                LandlordUID = landlord2.UID,
                Name = "House 5",
                PostCode = "TS5 2HR",
                Address = "Bennard Street, Middlesbrough TS5",
                CountryUID = 1,
                IsActive = true,
                CreatedBy = user2.UID,
                LastUpdatedBy = user2.UID,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now
            };
            var pa5 = new PropertyAttribute()
            {
                UID = Guid.NewGuid().ToString(),
                PropertyUID = p5.UID,
                PropertyTypeUID = 5,
                FurnishTypeUID = 1,
                BedroomCount = 4,
                BathroomCount = 2,
                FloorCount = 2,
                MaxOccupantCount = 8,
                ParkingSlotCount = 2,
                TotalAreaInSqFT = 2000,
                IsGarageAvailable = true,
                IsParkingSlotAvailable = true,
                IsBackyardAvailable = true,
                IsActive = true,
                CreatedBy = user2.UID,
                LastUpdatedBy = user2.UID,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now
            };
            var pl5 = new PropertyListing()
            {
                UID = Guid.NewGuid().ToString(),
                PropertyUID = p5.UID,
                ListedByUser = user2.UID,
                ListingDate = DateTime.Now,
                Description = "4 bed terraced house to rent",
                ListingAmount = 1850,
                IsCTIAvailableForSale = false,
                IsActive = true,
                CreatedBy = user2.UID,
                LastUpdatedBy = user2.UID,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now
            };
            var pla5 = new PropertyListingAttribute()
            {
                UID = Guid.NewGuid().ToString(),
                PropertyAttributeUID = pa5.UID,
                PropertyListingUID = pl5.UID,
                TenancyTypeUID = 10,
                Landmark = "0.5 miles Middlesbrough",
                AllowedOccupantCount = 12,
                AvailableBedroomCount = 4,
                AvailableBathroomCount = 2,
                AvailableParkingSlots = 2,
                IsNew = true,
                IsStudentFriendly = true,
                IsChildrenAllowed = true,
                IsParkingAvailable = true,
                IsPartyingAllowed = true,
                IsSharingAllowed = true,
                IsPetsAllowed = true,
                IsSmokingAllowed = true,
                IsUnisex = true,
                IsActive = true,
                CreatedBy = user2.UID,
                LastUpdatedBy = user2.UID,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now
            };
            modelBuilder.Entity<Property>().HasData(p5);
            modelBuilder.Entity<PropertyAttribute>().HasData(pa5);
            modelBuilder.Entity<PropertyListing>().HasData(pl5);
            modelBuilder.Entity<PropertyListingAttribute>().HasData(pla5);


        }

        private void PopulateStudentData(ModelBuilder modelBuilder)
        {
            var uniqueUID = Guid.NewGuid().ToString();
            var user1 = new User()
            {
                UID = uniqueUID,
                FirstName = "Nidhin",
                LastName = "Johny",
                UserName = "nidhin",
                Password = "johny",
                UserType = 0,
                Email = "nidhin.sde@gmail.com",
                IsActive = true,
                RoleUID = 2,
                CreatedBy = uniqueUID,
                LastUpdatedBy = uniqueUID,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now
            };
            modelBuilder.Entity<User>().HasData(user1);
        }
    }
}
