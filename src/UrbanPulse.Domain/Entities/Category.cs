using UrbanPulse.Domain.Common.Entities;

namespace UrbanPulse.Domain.Entities;

public class Category : BaseEntity
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string IconKey { get; set; } = string.Empty;
    public bool IsCritical { get; set; }
    public ICollection<CategoryTranslation> Translations { get; set; } = [];
}
