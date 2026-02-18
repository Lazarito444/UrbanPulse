using UrbanPulse.Domain.Common.Entities;

namespace UrbanPulse.Domain.Entities;

public class CategoryTranslation : BaseEntity
{
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public required string LanguageCode { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}
