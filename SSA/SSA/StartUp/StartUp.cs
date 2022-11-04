
using DataAccess;
using Microsoft.EntityFrameworkCore;

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
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(""))

                };
            });
        }

        private static void ConfigurePolicy(IServiceCollection services)
        {
            services.AddAuthorization();
        }

        private static void ConfigureDependency(IServiceCollection services, ConfigurationManager configManager)
        {
            services.AddDbContext<SSDbContext>(options => options.UseSqlServer(configManager.GetConnectionString("")));
            services.AddScoped<IAuthHandler,JWTAuthHandler>();
            services.AddScoped<IAuthenticationManager,AuthenticationManager>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IUniversityRepository, UniversityRepository>();
        }
    }
}
