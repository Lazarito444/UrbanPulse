using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrbanPulse.Domain.Entities;

namespace UrbanPulse.Infrastructure.EntityConfigurations;

public class CategoryTranslationConfig : IEntityTypeConfiguration<CategoryTranslation>
{
    public void Configure(EntityTypeBuilder<CategoryTranslation> builder)
    {
        builder.ToTable("CategoryTranslations");

        builder.HasKey(t => new { t.CategoryId, t.LanguageCode });

        builder.Property(t => t.LanguageCode)
            .HasMaxLength(5)
            .IsUnicode(false);

        builder.Property(t => t.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.Description)
            .IsRequired(false)
            .HasMaxLength(500);
    }
}
