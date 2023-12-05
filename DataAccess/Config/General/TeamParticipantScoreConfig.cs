using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config;

public class TeamParticipantScoreConfig:IEntityTypeConfiguration<TeamParticipantScore>
{
    public void Configure(EntityTypeBuilder<TeamParticipantScore> builder)
    {
        builder
            .HasKey(tps => new { tps.ParticipantId, tps.EventId, tps.ScoreId, tps.TeamId });

        builder
            .HasOne(tcs => tcs.Participant)
            .WithOne()
            .HasForeignKey<TeamParticipantScore>(tcs => tcs.ParticipantId);

        builder
            .HasOne(tcs => tcs.Event)
            .WithMany(e => e.ParticipantScores)
            .HasForeignKey(tcs => tcs.EventId);

        builder
            .HasOne(tcs => tcs.Team)
            .WithMany()
            .HasForeignKey(tcs => tcs.TeamId);

        builder
            .HasOne(tcs => tcs.Score)
            .WithOne()
            .HasForeignKey<TeamParticipantScore>(tcs => tcs.ScoreId);

    }
}