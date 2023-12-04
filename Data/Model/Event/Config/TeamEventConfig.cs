using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Model.Config;

public class TeamEventConfig:IEntityTypeConfiguration<TeamEvent>
{
    public void Configure(EntityTypeBuilder<TeamEvent> builder)
    {
        
        builder.HasMany(e => e.TeamScores)
            .WithOne()
            .HasForeignKey(e => e.Id);

        builder.HasMany(e => e.TeamParticipants)
            .WithOne()
            .HasForeignKey(e => e.Id);

        builder.HasMany(e => e.TeamSubstitutes)
            .WithOne()
            .HasForeignKey(e => e.Id);
              
        //Base
        builder.HasBaseType<Event>();
    }
}