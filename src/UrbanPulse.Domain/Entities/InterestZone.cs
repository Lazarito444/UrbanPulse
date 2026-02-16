using NetTopologySuite.Geometries;
using UrbanPulse.Domain.Common.Entities;

namespace UrbanPulse.Domain.Entities;

public class InterestZone : BaseEntity
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public double Radius { get; set; }
    public required Point Point { get; set; }
}
