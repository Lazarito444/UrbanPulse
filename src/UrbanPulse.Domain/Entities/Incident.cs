using NetTopologySuite.Geometries;
using UrbanPulse.Domain.Common.Entities;
using UrbanPulse.Domain.Enums.Incidents;

namespace UrbanPulse.Domain.Entities;

public class Incident : BaseEntity
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public required Point { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }
    public IncidentStatus Status { get; set; }
}
