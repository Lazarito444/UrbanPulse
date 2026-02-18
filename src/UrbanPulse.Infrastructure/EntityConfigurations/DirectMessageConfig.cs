using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrbanPulse.Domain.Entities;

namespace UrbanPulse.Infrastructure.EntityConfigurations;

public class DirectMessageConfig : BaseEntityConfig<DirectMessage>
{
    public override void Configure(EntityTypeBuilder<DirectMessage> builder)
    {
        base.Configure(builder);

        builder.ToTable("DirectMessages");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => new { x.SenderId, x.ReceiverId });

        builder.Property(x => x.Content)
            .HasMaxLength(1000)
            .IsRequired();

        builder.HasOne(x => x.Sender)
            .WithMany(u => u.SentDirectMessages)
            .HasForeignKey(x => x.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Receiver)
            .WithMany(u => u.ReceivedDirectMessages)
            .HasForeignKey(x => x.ReceiverId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
