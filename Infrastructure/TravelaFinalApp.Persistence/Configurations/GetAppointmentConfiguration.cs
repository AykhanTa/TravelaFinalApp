using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Persistence.Configurations
{
    public class GetAppointmentConfiguration : IEntityTypeConfiguration<GetAppointment>
    {
        public void Configure(EntityTypeBuilder<GetAppointment> builder)
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

            builder.Property(d=>d.PersonCount)
                .IsRequired();

            builder.Property(d => d.KidsCount)
                .IsRequired();

            builder.Property(d => d.Destination)
                .IsRequired()
                .HasMaxLength(35);

            builder.Property(d => d.DateTime)
                .IsRequired();

            builder.Property(d => d.Content)
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}
