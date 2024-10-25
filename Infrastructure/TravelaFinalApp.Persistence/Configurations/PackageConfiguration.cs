using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Persistence.Configurations
{
    public class PackageConfiguration : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Price)
                .IsRequired();

            builder.Property(p => p.HotelDeals)
                .IsRequired();

            builder.Property(p => p.Content)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(p => p.Duration)
                .IsRequired();

            builder.Property(p => p.PersonCount)
                .IsRequired();

            builder.HasOne(p => p.Destination)
            .WithMany(d => d.Packages)
            .HasForeignKey(p => p.DestinationId)
            .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
