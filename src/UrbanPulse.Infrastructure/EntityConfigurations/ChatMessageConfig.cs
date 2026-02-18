using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrbanPulse.Domain.Entities;

namespace UrbanPulse.Infrastructure.EntityConfigurations;

public class ChatMessageConfig : BaseEntityConfig<ChatMessage>
{
    public override void Configure(EntityTypeBuilder<ChatMessage> builder)
    {
        base.Configure(builder);

        builder.ToTable("ChatMessages");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Content)
            .HasMaxLength(1000)
            .IsRequired();

        builder.HasOne(x => x.Incident)
            .WithMany(i => i.ChatMessages)
            .HasForeignKey(x => x.IncidentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
