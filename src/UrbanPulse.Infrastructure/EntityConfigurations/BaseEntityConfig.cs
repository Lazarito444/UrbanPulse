using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrbanPulse.Domain.Common.Entities;
using UrbanPulse.Infrastructure.Constants;

namespace UrbanPulse.Infrastructure.EntityConfigurations;

public abstract class BaseEntityConfig<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Metadata.SetSchema("app");

        builder.Property(x => x.CreatedAtUtc)
            .IsRequired();

        builder.Property(x => x.UpdatedAtUtc)
            .IsRequired(false);

        builder.Property(x => x.IsDeleted)
            .IsRequired()
            .HasDefaultValue(false);

        builder.HasQueryFilter(QueryFilters.SoftDelete, x => !x.IsDeleted);
    }
}
