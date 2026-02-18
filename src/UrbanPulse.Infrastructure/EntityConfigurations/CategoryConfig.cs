using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrbanPulse.Domain.Entities;

namespace UrbanPulse.Infrastructure.EntityConfigurations;

public class CategoryConfig : BaseEntityConfig<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);

        builder.ToTable("Categories");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.IconKey)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.IsCritical)
            .HasDefaultValue(false);

        builder.HasMany(x => x.Translations)
            .WithOne()
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
