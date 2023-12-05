using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config;

public class TeamEventConfig:IEntityTypeConfiguration<TeamEvent>
{
    public void Configure(EntityTypeBuilder<TeamEvent> builder)
    {
        builder
            .HasMany(e => e.TeamParticipants)
            .WithOne(p => p.Event)
            .HasForeignKey(e => e.EventId);

        builder
            .HasMany(e => e.TeamSubstitutes)
            .WithOne(p => p.Event)
            .HasForeignKey(e => e.EventId);

    }
}