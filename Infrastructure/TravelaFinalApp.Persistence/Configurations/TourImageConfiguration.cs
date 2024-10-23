using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Persistence.Configurations
{
    public class TourImageConfiguration : IEntityTypeConfiguration<TourImage>
    {
        public void Configure(EntityTypeBuilder<TourImage> builder)
        {
            builder.HasOne(ti => ti.Tour)
                .WithMany(t => t.TourImages)
                .HasForeignKey(ti => ti.TourId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
