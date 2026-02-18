using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrbanPulse.Domain.Entities;

namespace UrbanPulse.Infrastructure.EntityConfigurations;

public class VoteConfig : BaseEntityConfig<Vote>
{
    public override void Configure(EntityTypeBuilder<Vote> builder)
    {
        builder.ToTable("Votes");

        builder.HasKey(v => new { v.UserId, v.IncidentId });

        builder.Property(v => v.IsUpvote)
            .IsRequired();

        builder.HasOne(v => v.User)
            .WithMany(u => u.Votes)
            .HasForeignKey(v => v.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(v => v.Incident)
            .WithMany(i => i.Votes)
            .HasForeignKey(v => v.IncidentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
