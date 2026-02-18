using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrbanPulse.Domain.Entities;

namespace UrbanPulse.Infrastructure.EntityConfigurations;

public class InterestZoneConfig : BaseEntityConfig<InterestZone>
{
    public override void Configure(EntityTypeBuilder<InterestZone> builder)
    {
        base.Configure(builder);

        builder.ToTable("InterestZones");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Point)
            .IsRequired()
            .HasColumnType("GEOGRAPHY");

        builder.Property(x => x.Radius)
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithMany(u => u.InterestZones)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
