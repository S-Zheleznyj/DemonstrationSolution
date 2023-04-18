using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProcessMe.Data;
using ProcessMe.Data.Implementation;
using ProcessMe.Data.Interfaces;
using ProcessMe.Domain.Managers.Implementation;
using ProcessMe.Domain.Managers.Interfaces;
using ProcessMe.Infrastructure.Configurations;
using ProcessMe.Infrastructure.Validation;
using System.Text;

namespace ProcessMe.Infrastructure.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        /// <summary> Конфигурирует контекст базы данных</summary>
        public static void ConfigureDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ProcessMeDbContext>(options =>
            {
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("ProcessMe"));
            });
        }

        /// <summary> Конфигурирует репозитории</summary>
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAppealRepo, AppealRepo>();
            services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            services.AddScoped<IRatingRepo, RatingRepo>();
            //services.AddScoped<IRoleRepo, RoleRepo>();
            //services.AddScoped<IUserRepo, UserRepo>();
        }

        /// <summary> Конфигурирует доменные менеджеры</summary>
        public static void ConfigureDomainManagers(this IServiceCollection services)
        {
            services.AddScoped<IAppealManager, AppealManager>();
            services.AddScoped<IDepartmentManager, DepartmentManager>();
            services.AddScoped<IEmployeeManager, EmployeeManager>();
            services.AddScoped<IRatingManager, RatingManager>();
            //services.AddScoped<IRoleManager, RoleManager>();
            //services.AddScoped<IUserManager, UserManager>();
        }

        /// <summary> Конфигурирует валидаторы</summary>
        public static void ConfigureValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<AppealForCreationDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<UserRegistrationRequestDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<UserLoginRequestDtoValidator>();
        }

        /// <summary> Конфигурирует Jwt</summary>
        public static void ConfigureJwtConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtConfig>(configuration.GetSection("JwtConfig"));
        }

        /// <summary> Конфигурирует Jwt</summary>
        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt =>
            {
                var key = Encoding.ASCII.GetBytes(configuration.GetSection("JwtConfig:Secret").Value);

                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false, // for dev
                    ValidateAudience = false, // for dev
                    RequireExpirationTime = false, //for dev
                    ValidateLifetime = true
                };
            });
        }

        /// <summary> Конфигурирует Swagger</summary>
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference(){Type = ReferenceType.SecurityScheme, Id = "Bearer"}
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }
    }
}
