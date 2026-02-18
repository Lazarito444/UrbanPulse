using UrbanPulse.Domain.Common.Entities;
using UrbanPulse.Domain.Enums.Users;

namespace UrbanPulse.Domain.Entities;

public class User : BaseEntity
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public double ReputationScore { get; set; }
    public UserRole Role { get; set; }

    // NAVIGATION PROPERTIES
    public ICollection<Incident> Incidents { get; set; } = [];
    public ICollection<Vote> Votes { get; set; } = [];
    public ICollection<ChatMessage> ChatMessages { get; set; } = [];
    public ICollection<InterestZone> InterestZones { get; set; } = [];
    public ICollection<DirectMessage> SentDirectMessages { get; set; } = [];
    public ICollection<DirectMessage> ReceivedDirectMessages { get; set; } = [];
}
