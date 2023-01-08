
using Business.Interface.Validators;
using Business.Validators;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using SSA.Middlewares;
using System.Reflection;
using System.Security.Claims;

namespace SSA.StartUp
{
    public class StartUp
    {
        public static void Configure(ConfigurationManager configManager,IServiceCollection services)
        {
            ConfigureDistributedCache(services);
            ConfigureAuthentication(services);
            ConfigurePolicy(services);
            ConfigureDependency(services,configManager);
        }

        public static TokenValidationParameters GetConfiguredTokenValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(GlobalConstant.SigningKey)),
                ClockSkew = TimeSpan.Zero
            };
        }

        private static void ConfigureAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = GetConfiguredTokenValidationParameters();
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if(context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("IS-TOKEN-EXPIRED", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });
        }

        private static void ConfigurePolicy(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(GlobalConstant.AllUsersPolicy, policyBuilder => policyBuilder.RequireClaim(ClaimTypes.Role, GlobalConstant.AdminRole, 
                    GlobalConstant.UniversityRole, GlobalConstant.ConsultantRole, GlobalConstant.StudentRole, GlobalConstant.LandlordRole));
                options.AddPolicy(GlobalConstant.StudentCreatorPolicy, policyBuilder => policyBuilder.RequireClaim(ClaimTypes.Role, 
                    GlobalConstant.AdminRole, GlobalConstant.UniversityRole,GlobalConstant.ConsultantRole));
                options.AddPolicy(GlobalConstant.StudentPolicy, policyBuilder => policyBuilder.RequireClaim(ClaimTypes.Role, GlobalConstant.StudentRole));
                options.AddPolicy(GlobalConstant.UniversityPolicy, policyBuilder => policyBuilder.RequireClaim(ClaimTypes.Role, 
                    GlobalConstant.UniversityRole));
                options.AddPolicy(GlobalConstant.LandlordPolicy, policyBuilder => policyBuilder.RequireClaim(ClaimTypes.Role, GlobalConstant.LandlordRole));
                options.AddPolicy(GlobalConstant.ConsultantPolicy, policyBuilder => policyBuilder.RequireClaim(ClaimTypes.Role, 
                    GlobalConstant.ConsultantRole));
                options.AddPolicy(GlobalConstant.PropertyPolicy, policyBuilder => policyBuilder.RequireClaim(ClaimTypes.Role, GlobalConstant.LandlordRole,
                    GlobalConstant.ConsultantRole,GlobalConstant.AdminRole));
                options.AddPolicy(GlobalConstant.PropertyListingPolicy, policyBuilder => policyBuilder.RequireClaim(ClaimTypes.Role, GlobalConstant.LandlordRole,
                        GlobalConstant.ConsultantRole, GlobalConstant.AdminRole));
                options.AddPolicy(GlobalConstant.PropertyViewingPolicy, policyBuilder => policyBuilder.RequireClaim(ClaimTypes.Role, 
                        GlobalConstant.LandlordRole, GlobalConstant.StudentRole));
                options.AddPolicy(GlobalConstant.AdminPolicy, policyBuilder => policyBuilder.RequireClaim(ClaimTypes.Role,
                            GlobalConstant.AdminRole));
                options.AddPolicy(GlobalConstant.AllTenantsPolicy, policyBuilder => policyBuilder.RequireClaim(ClaimTypes.Role,
                            GlobalConstant.StudentRole, GlobalConstant.AdminRole));
            });
        }

        private static void ConfigureDependency(IServiceCollection services, ConfigurationManager configManager)
        {
            
            services.AddDbContext<SSDbContext>(options => options.UseSqlServer(GetEnvironmentVariable("DBConnection")));
            services.AddScoped<IAuthHandler,JWTAuthHandler>();
            services.AddScoped<IAuthenticationManager,AuthenticationManager>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IStudentRepository, StudentRepository>();
            //services.AddScoped<IUniversityRepository, UniversityRepository>();
            //services.AddScoped<ICountryRepository, CountryRepository>();
            //services.AddScoped<IPropertyRepository, PropertyRepository>();
            //services.AddScoped<IRolesRepository, RolesRepository>();
            //services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserValidator, UserValidator>();
            services.AddScoped<IStudentValidator, StudentValidator>();
            services.AddScoped<ILandlordValidator, LandlordValidator>();
            services.AddScoped<IPropertyValidator, PropertyValidator>();
            //services.AddScoped<IImageFileValidator, ImageFileValidator>();
            services.AddScoped<ITenantValidator, TenantValidator>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IStudentManager, StudentManager>();
            services.AddScoped<ILandlordManager,LandlordManager>();
            services.AddScoped<IPropertyManager, PropertyManager>();
            services.AddScoped<IMasterDataManager, MasterDataManager>();
            services.AddScoped<ITenantManager, TenantManager>();
            var fileStorageServiceType = configManager.GetSection("FileServiceHost").Value;
            if (fileStorageServiceType == GlobalConstant.Azure)
            {
                services.AddScoped<IFileService, AzureFileStorageService>((provider) =>
                {
                    var storageAccountConnectionString = GetEnvironmentVariable("AZURE_STORAGE_CONNECTION");
                    return new AzureFileStorageService(storageAccountConnectionString);
                });
            }
            else
            {
                services.AddScoped<IFileService, LocalFileServiceManager>();

            }
            
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<TokenManagerMiddleware>();
        }

        private static void ConfigureDistributedCache(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
        }

        public static string GetEnvironmentVariable(string name)
        {
            return Environment.GetEnvironmentVariable(name)??string.Empty;
        }

    }
}
