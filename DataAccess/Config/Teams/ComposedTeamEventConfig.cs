using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config;

public class ComposedTeamEventConfig:IEntityTypeConfiguration<ComposedTeamsEvent>
{
    public void Configure(EntityTypeBuilder<ComposedTeamsEvent> builder)
    {
        builder
            .HasMany(e => e.ComposedTeams)
            .WithMany();

        builder
            .HasMany(e => e.ComposedTeamScores)
            .WithOne()
            .HasForeignKey("EventId");
    }
}