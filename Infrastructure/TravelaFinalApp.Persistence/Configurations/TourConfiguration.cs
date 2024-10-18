using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Persistence.Configurations
{
    public class TourConfiguration : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> builder)
        {
            builder.Property(t => t.Place)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.Price)
                .IsRequired();

            builder.Property(t => t.DiscountPercent)
                .IsRequired();

            builder.Property(t => t.Content)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(t => t.Date)
                .IsRequired();

            builder.Property(t => t.Duration)
                .IsRequired();
        }
    }
}
