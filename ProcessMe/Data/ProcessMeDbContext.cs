using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProcessMe.Data.Configurations;
using ProcessMe.Models.Entities;

namespace ProcessMe.Data
{
    public class ProcessMeDbContext : IdentityDbContext
    {
        public DbSet<Appeal> Appeals { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<User> Users { get; set; }
        public ProcessMeDbContext(DbContextOptions<ProcessMeDbContext> options) : base(options)
        {

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.ApplyConfiguration(new AppealConfiguration());
        //    //modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        //    //modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        //    //modelBuilder.ApplyConfiguration(new RatingConfiguration());
        //    //modelBuilder.ApplyConfiguration(new RoleConfiguration());
        //    //modelBuilder.ApplyConfiguration(new UserConfiguration());
        //}
    }
}
