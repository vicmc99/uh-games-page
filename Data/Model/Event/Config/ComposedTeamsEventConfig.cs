using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Model.Config;

public class ComposedTeamsEventConfig:IEntityTypeConfiguration<ComposedTeamsEvent>
{
    public void Configure(EntityTypeBuilder<ComposedTeamsEvent> builder)
    {
        // Nav Config
        builder.HasMany(e => e.ComposedTeams)
            .WithOne()
            .HasForeignKey("ComposedTeamsEventId");

        builder.HasMany(e => e.ComposedTeamScores)
            .WithOne()
            .HasForeignKey("ComposedTeamsEventId");
        
        
        //Base
        builder.HasBaseType<Event>();
    }
}