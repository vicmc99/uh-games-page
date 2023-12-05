using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config;

public class TeamEventParticipantConfig:IEntityTypeConfiguration<TeamEventParticipant>
{
    public void Configure(EntityTypeBuilder<TeamEventParticipant> builder)
    {
        
      builder
            .HasOne(t => t.Team)
            .WithMany()
            .HasForeignKey(t => t.TeamId);

     builder  
            .HasOne(t => t.Event)
            .WithMany()
            .HasForeignKey(t => t.EventId);

    builder
            .HasOne(t => t.Participant)
            .WithMany()
            .HasForeignKey(t => t.ParticipantId);

    }
}