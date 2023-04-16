using Microsoft.EntityFrameworkCore;
using ProcessMe.Data;
using ProcessMe.Data.Implementation;
using ProcessMe.Data.Interfaces;
using ProcessMe.Domain.Managers.Implementation;
using ProcessMe.Domain.Managers.Interfaces;

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
            services.AddScoped<IRoleRepo, RoleRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
        }

        /// <summary> Конфигурирует доменные менеджеры</summary>
        public static void ConfigureDomainManagers(this IServiceCollection services)
        {
            services.AddScoped<IAppealManager, AppealManager>();
            services.AddScoped<IDepartmentManager, DepartmentManager>();
            services.AddScoped<IEmployeeManager, EmployeeManager>();
            services.AddScoped<IRatingManager, RatingManager>();
            services.AddScoped<IRoleManager, RoleManager>();
            services.AddScoped<IUserManager, UserManager>();
        }
    }
}
