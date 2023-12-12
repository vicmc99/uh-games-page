using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Event = Data.Entities.Event;

namespace DataAccess.Config;

public class EventConfig:IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasDiscriminator<string>("EventType")
            .HasValue<ComposedTeamsEvent>("ComposedTeamsEvent")
            .HasValue<TeamEvent>("TeamEvent")
            .HasValue<MatchEvent>("MatchEvent")
            .HasValue<ParticipantScoredEvent>("ParticipantScoredEvent");

    }
}