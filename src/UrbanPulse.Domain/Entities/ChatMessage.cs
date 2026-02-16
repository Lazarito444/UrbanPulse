using UrbanPulse.Domain.Common.Entities;

namespace UrbanPulse.Domain.Entities;

public class ChatMessage : BaseEntity
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string Content { get; set; } = string.Empty;
    public DateTime SentAt { get; set; } = DateTime.UtcNow;
    public Guid IncidentId { get; set; }
    public Incident? Incident { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
}
