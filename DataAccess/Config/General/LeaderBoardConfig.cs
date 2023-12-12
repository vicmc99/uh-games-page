using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config;

public class LeaderBoardConfig:IEntityTypeConfiguration<Leaderboard>
{
    public void Configure(EntityTypeBuilder<Leaderboard> builder)
    {
       builder
            .HasMany(l => l.LeaderboardLines)
            .WithOne()
            .HasForeignKey("LeaderboardId");
    }
}