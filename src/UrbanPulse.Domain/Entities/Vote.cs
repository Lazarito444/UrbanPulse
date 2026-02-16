using UrbanPulse.Domain.Common.Entities;

namespace UrbanPulse.Domain.Entities;

public class Vote : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid IncidentId { get; set; }
    public bool IsUpvote { get; set; }
}
