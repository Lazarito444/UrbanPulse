using UrbanPulse.Domain.Common.Entities;

namespace UrbanPulse.Domain.Entities;

public class Category : BaseEntity
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string Name { get; set; } = string.Empty;
    public string IconKey { get; set; } = string.Empty;
    public bool IsCritical { get; set; }
}
