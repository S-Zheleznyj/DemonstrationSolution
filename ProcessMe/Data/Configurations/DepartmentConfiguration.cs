using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcessMe.Infrastructure.Enums;
using ProcessMe.Models.Entities;

namespace ProcessMe.Data.Configurations
{
    internal sealed class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        void IEntityTypeConfiguration<Department>.Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");

            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasColumnName("Id");

            builder.Property(x => x.Type)
                .HasConversion(
                d => d.ToString(),
                d => (DepartmentType)System.Enum.Parse(typeof(DepartmentType), d));
        }
    }
}
