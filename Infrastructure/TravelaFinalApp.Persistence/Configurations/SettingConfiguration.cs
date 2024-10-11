using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Persistence.Configurations
{
    public class SettingConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.Property(s => s.Key)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.Value)
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}
