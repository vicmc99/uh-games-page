﻿using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config;

public class ParticipantScoredEventSubstituteConfig:IEntityTypeConfiguration<ParticipantScoredEventSubstitute>
{
   
    public void Configure(EntityTypeBuilder<ParticipantScoredEventSubstitute> builder)
    {
        builder
            .HasKey(t => new { t.EventId, t.TeamId, t.SubstituteId });

        builder
            .HasOne(t => t.Team)
            .WithMany()
            .HasForeignKey(t => t.TeamId);

        builder
            .HasOne(t => t.Event)
            .WithMany()
            .HasForeignKey(t => t.EventId);

        builder
            .HasOne(t => t.Substitute)
            .WithMany()
            .HasForeignKey(t => t.SubstituteId);
    }
}