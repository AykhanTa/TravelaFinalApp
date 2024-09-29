using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Persistence.Configurations
{
    public class AboutConfiguration : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(a => a.Image)
                .IsRequired();

        }
    }
}
