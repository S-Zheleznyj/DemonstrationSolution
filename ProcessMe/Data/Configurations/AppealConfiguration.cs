using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcessMe.Infrastructure.Enums;
using ProcessMe.Models.Entities;

namespace ProcessMe.Data.Configurations
{
    internal sealed class AppealConfiguration : IEntityTypeConfiguration<Appeal>
    {
        public void Configure(EntityTypeBuilder<Appeal> builder)
        {
            builder.ToTable("Appeals");

            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasColumnName("Id");

            builder.HasOne(appeal => appeal.Employee)
                .WithMany(employee => employee.Appeals)
                .HasForeignKey("EmployeeId");

            builder.Property(x => x.CommunicationWay)
                .HasConversion(
                cw => cw.ToString(),
                cw => (CommunicationType)System.Enum.Parse(typeof(CommunicationType), cw));
        }
    }
}
