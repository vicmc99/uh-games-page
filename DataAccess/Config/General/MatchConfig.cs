using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config;

public class MatchConfig:IEntityTypeConfiguration<Match>
{
    public void Configure(EntityTypeBuilder<Match> builder)
    {
        builder 
            .HasMany(m => m.ParticipantScores)
            .WithOne()
            .HasForeignKey("MatchId");
    }
}