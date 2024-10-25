using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Persistence.Configurations
{
    public class PackageImageConfiguration : IEntityTypeConfiguration<PackageImage>
    {
        public void Configure(EntityTypeBuilder<PackageImage> builder)
        {
            builder.Property(pi => pi.Name)
                .IsRequired();

            builder.Property(pi => pi.IsMain)
                .IsRequired();

            builder.HasOne(pi => pi.Package)
                .WithMany(p => p.PackageImages)
                .HasForeignKey(pi => pi.PackageId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
