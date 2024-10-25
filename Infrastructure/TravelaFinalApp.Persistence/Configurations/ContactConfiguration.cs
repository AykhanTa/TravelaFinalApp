using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Persistence.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(c => c.FullName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.Phone)
                .IsRequired()
                .HasMaxLength(20); 

            builder.Property(a => a.Email)

                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Subject)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Message)
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}
