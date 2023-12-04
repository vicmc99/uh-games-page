using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Model.Config;

public class ParticipantScoredEventConfig:IEntityTypeConfiguration<ParticipantScoredEvent>
{
    public void Configure(EntityTypeBuilder<ParticipantScoredEvent> builder)
    {
        builder.HasMany(e => e.ParticipantScores)
            .WithOne()
            .HasForeignKey(e => e.Id);

        builder.HasMany(e => e.ParticipantScoredTeams)
            .WithOne()
            .HasForeignKey(e => e.Id);

        builder.HasMany(e => e.TeamSubstitutes)
            .WithOne()
            .HasForeignKey(e => e.Id);
              
        //Base
        builder.HasBaseType<Event>();
    }
}