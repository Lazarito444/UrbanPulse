namespace UrbanPulse.Domain.Common.Entities;

public class BaseEntity : IAuditableEntity
{
    public DateTime CreatedAtUtc { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }
    public bool IsDeleted { get; set; }
}
