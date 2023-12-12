﻿using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config;

public class TournamentConfig:IEntityTypeConfiguration<Tournament>
{
    public void Configure(EntityTypeBuilder<Tournament> builder)
    { //Keys 
        builder.HasIndex(e => new { e.StartDate, e.EndDate, e.Rounds }).IsUnique();
        builder.Property(e =>  e.StartDate).IsRequired();
        builder.Property(e =>  e.EndDate).IsRequired();
        builder.Property(e =>  e.Rounds).IsRequired();
        
        //Relationships 
        //Locations
        builder
            .HasMany(t => t.Locations)
            .WithMany();
    }
}