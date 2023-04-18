using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProcessMe.Models.Entities;
using ProcessMe.Infrastructure.Enums;

namespace ProcessMe.Data.Configurations
{
    //internal sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
    //{
    //    public void Configure(EntityTypeBuilder<Role> builder)
    //    {
    //        builder.ToTable("Roles");

    //        builder.Property(x => x.Id)
    //            .ValueGeneratedNever()
    //            .HasColumnName("Id");

    //        builder.Property(x => x.Type)
    //            .HasConversion(
    //            r => r.ToString(),
    //            r => (RoleType)System.Enum.Parse(typeof(RoleType), r));
    //    }
    //}
}
