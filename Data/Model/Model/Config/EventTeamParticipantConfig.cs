using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Model.Config;

public class EventTeamParticipantConfig:IEntityTypeConfiguration<EventTeamParticipant>
{
    public void Configure(EntityTypeBuilder<EventTeamParticipant> builder)
    {
        builder.HasOne(e => e.Team)
            .WithMany()
            .HasForeignKey(e => e.TeamId)
            .IsRequired();

        builder.HasOne(e => e.Event)
            .WithMany()
            .HasForeignKey(e => e.EventId)
            .IsRequired();

        builder.HasOne(e => e.Participant)
            .WithMany()
            .HasForeignKey(e => e.ParticipantId)
            .IsRequired();

        builder.HasOne(e => e.TeamEvent)
            .WithMany()
            .HasForeignKey(e => e.TeamEventId);
    }
}