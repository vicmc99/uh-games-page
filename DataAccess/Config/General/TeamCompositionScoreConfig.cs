using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config;

public class TeamCompositionScoreConfig:IEntityTypeConfiguration<TeamCompositionScore>
{
    public void Configure(EntityTypeBuilder<TeamCompositionScore> builder)
    {
        builder
            .HasKey(tcs => new { tcs.CompositionId, tcs.ScoreId });

        builder
            .HasOne(tcs => tcs.Composition)
            .WithMany()
            .HasForeignKey(tcs => tcs.CompositionId);

        builder
            .HasOne(tcs => tcs.Score)
            .WithOne()
            .HasForeignKey<TeamCompositionScore>(tcs => tcs.ScoreId);

    }
}