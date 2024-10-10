using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Persistence.Configurations
{
    public class GuideConfiguration : IEntityTypeConfiguration<Guide>
    {
        public void Configure(EntityTypeBuilder<Guide> builder)
        {
            builder.Property(g => g.FullName)
                .IsRequired()
                .HasMaxLength(30);
            
            builder.Property(g=>g.Designation)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(g => g.Image)
                .IsRequired();
        }
    }
}
