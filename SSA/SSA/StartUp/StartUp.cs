
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Claims;

namespace SSA.StartUp
{
    public class StartUp
    {
        public static void Configure(ConfigurationManager configManager,IServiceCollection services)
        {
            ConfigureAuthentication(services);
            ConfigurePolicy(services);
            ConfigureDependency(services,configManager);
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
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(GlobalConstant.EncryptionKey))

                };
            });
        }

        private static void ConfigurePolicy(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(GlobalConstant.StudentCreatorPolicy, policyBuilder => policyBuilder.RequireClaim(ClaimTypes.Role, GlobalConstant.AdminRole, GlobalConstant.UniversityRole,GlobalConstant.ConsultantRole));
                options.AddPolicy(GlobalConstant.StudentPolicy, policyBuilder => policyBuilder.RequireClaim(ClaimTypes.Role, GlobalConstant.StudentRole));
                options.AddPolicy(GlobalConstant.UniversityPolicy, policyBuilder => policyBuilder.RequireClaim(ClaimTypes.Role, GlobalConstant.UniversityRole));
                options.AddPolicy(GlobalConstant.LandlordPolicy, policyBuilder => policyBuilder.RequireClaim(ClaimTypes.Role, GlobalConstant.LandlordRole));
                options.AddPolicy(GlobalConstant.ConsultantPolicy, policyBuilder => policyBuilder.RequireClaim(ClaimTypes.Role, GlobalConstant.ConsultantRole));
            });
        }

        private static void ConfigureDependency(IServiceCollection services, ConfigurationManager configManager)
        {
            services.AddDbContext<SSDbContext>(options => options.UseSqlServer(configManager.GetConnectionString("DBConnection")));
            services.AddScoped<IAuthHandler,JWTAuthHandler>();
            services.AddScoped<IAuthenticationManager,AuthenticationManager>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IUniversityRepository, UniversityRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
