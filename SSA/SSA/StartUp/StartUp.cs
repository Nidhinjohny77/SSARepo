
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
            services.AddTransient<TokenManagerMiddleware>();
        }

        private static void ConfigureDistributedCache(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
        }

    }
}
