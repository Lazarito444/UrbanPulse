using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrbanPulse.Domain.Entities;

namespace UrbanPulse.Infrastructure.EntityConfigurations;

public class IncidentConfiguration : BaseEntityConfig<Incident>
{
    public override void Configure(EntityTypeBuilder<Incident> builder)
    {
        base.Configure(builder);

        builder.ToTable("Incidents");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(4000)
            .IsRequired();

        builder.Property(x => x.Location)
            .IsRequired()
            .HasColumnType("GEOGRAPHY");

        builder.HasIndex(x => x.Location);

        builder.Property(x => x.Status)
            .HasConversion<int>()
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithMany(u => u.Incidents)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Category)
            .WithMany()
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
