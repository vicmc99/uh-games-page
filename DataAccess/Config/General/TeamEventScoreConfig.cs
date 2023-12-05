using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config;

public class TeamEventScoreConfig:IEntityTypeConfiguration<TeamEventScore>
{
    public void Configure(EntityTypeBuilder<TeamEventScore> builder)
    {
        
        builder
            .HasKey(e => new { e.TeamId, e.EventId, e.ScoreId });

        builder
            .HasOne(e => e.Event)
            .WithMany(e => e.TeamScores)
            .HasForeignKey(e => e.EventId);

        builder
            .HasOne(e => e.Score)
            .WithOne()
            .HasForeignKey<TeamEventScore>(e => e.ScoreId);

        builder
            .HasOne(e => e.Team)
            .WithMany()
            .HasForeignKey(e => e.TeamId);

    }
}