using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config;

public class MatchEventConfig:IEntityTypeConfiguration<MatchEvent>
{
    public void Configure(EntityTypeBuilder<MatchEvent> builder)
    {
        builder
            .HasMany(m => m.MatchedTeams)
            .WithMany();

        builder
            .HasMany(m => m.Matches)
            .WithOne()
            .HasForeignKey("EventId");

    }
}