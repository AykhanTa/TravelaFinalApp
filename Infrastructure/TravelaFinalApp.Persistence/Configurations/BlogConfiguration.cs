using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Persistence.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.Content)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(b=>b.Author)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.Image)
                .IsRequired();
        }
    }
}
