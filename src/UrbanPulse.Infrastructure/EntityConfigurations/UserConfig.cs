using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrbanPulse.Domain.Entities;

namespace UrbanPulse.Infrastructure.EntityConfigurations;

public class UserConfig : BaseEntityConfig<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.ToTable("Users");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Username)
            .HasMaxLength(60)
            .IsRequired();

        builder.Property(x => x.Email)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.ReputationScore)
            .HasPrecision(5, 2)
            .HasDefaultValue(0);

        builder.Property(x => x.Role)
            .HasConversion<int>()
            .IsRequired();

        builder.HasIndex(x => x.Username)
            .IsUnique();

        // TODO: ADD COLLATION FOR CASE INSENSITIVE EMAIL
        builder.HasIndex(x => x.Email)
            .IsUnique();
    }
}
