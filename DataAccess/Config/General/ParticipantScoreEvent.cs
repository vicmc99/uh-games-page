using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config;

public class ParticipantScoreEvent:IEntityTypeConfiguration<ParticipantScoredEvent>
{
    public void Configure(EntityTypeBuilder<ParticipantScoredEvent> builder)
    {
        builder
            .HasMany(e => e.ParticipantScoredTeams)
            .WithMany();
    }
}