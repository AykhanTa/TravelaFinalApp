using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Persistence.Configurations
{
    public class TestimonialConfiguration : IEntityTypeConfiguration<Testimonial>
    {
        public void Configure(EntityTypeBuilder<Testimonial> builder)
        {
            builder.Property(s => s.FullName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.Country)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(s => s.Description)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(s => s.Image)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
