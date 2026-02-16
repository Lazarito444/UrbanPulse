using UrbanPulse.Domain.Common.Entities;

namespace UrbanPulse.Domain.Entities;

public class DirectMessage : BaseEntity
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Guid SenderId { get; set; }
    public User? Sender { get; set; }
    public Guid ReceiverId { get; set; }
    public User? Receiver { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime SentAt { get; set; } = DateTime.UtcNow;

}
