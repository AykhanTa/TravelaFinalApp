using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Persistence.Configurations
{
    public class GuideSocialConfiguration : IEntityTypeConfiguration<GuideSocial>
    {
        public void Configure(EntityTypeBuilder<GuideSocial> builder)
        {
            builder.Property(gs=>gs.Instagram)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(gs => gs.Facebook)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(gs => gs.Twitter)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(gs => gs.Linkedin)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(gs => gs.Guide)
                .WithMany(g => g.GuideSocials)
                .HasForeignKey(gs => gs.GuideId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
