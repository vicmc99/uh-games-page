using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config;

public class LeaderBoardConfig:IEntityTypeConfiguration<Leaderboard>
{
    public void Configure(EntityTypeBuilder<Leaderboard> builder)
    {
        builder.HasIndex(e => e.Year).IsUnique();
        builder.HasMany(e => e.LeaderboardLines)
            .WithOne(e => e.Leaderboard)
            .HasForeignKey(e => e.LeaderBoardId);
    }
}