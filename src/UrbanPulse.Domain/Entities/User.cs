using UrbanPulse.Domain.Common.Entities;
using UrbanPulse.Domain.Enums.Users;

namespace UrbanPulse.Domain.Entities;

public class User : BaseEntity
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string Username { get; set; } = string.Empty;
    public double ReputationScore { get; set; }
    public UserRole Role { get; set; }
}
