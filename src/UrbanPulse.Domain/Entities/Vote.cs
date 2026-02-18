using UrbanPulse.Domain.Common.Entities;

namespace UrbanPulse.Domain.Entities;

public class Vote : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public Guid IncidentId { get; set; }
    public Incident Incident { get; set; } = null!;
    public bool IsUpvote { get; set; }
}
