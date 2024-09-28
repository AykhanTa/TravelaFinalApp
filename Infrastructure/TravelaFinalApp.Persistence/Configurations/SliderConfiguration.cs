using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Persistence.Configurations
{
    public class SliderConfiguration : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.Property(s => s.Title)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(s => s.SubTitle)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(s=>s.Description)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(s => s.Image)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
