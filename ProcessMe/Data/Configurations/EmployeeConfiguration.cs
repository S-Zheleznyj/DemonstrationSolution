using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcessMe.Models.Entities;

namespace ProcessMe.Data.Configurations
{
    internal sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employess");

            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasColumnName("Id");

            builder.HasOne(employee => employee.Department)
                .WithMany(department => department.Employees)
                .HasForeignKey("DepartmentId");

            //builder.HasOne(employee => employee.User)
            //    .WithMany(user => user.Employees)
            //    .HasForeignKey("UserId");
        }
    }
}
