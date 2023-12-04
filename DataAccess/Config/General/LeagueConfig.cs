using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config;

public class LeagueConfig:IEntityTypeConfiguration<League>
{
    public void Configure(EntityTypeBuilder<League> builder)
    {
        
        builder.Property(e => e.StartDate)
            .HasColumnType("date").IsRequired();
        builder.Property(e => e.EndDate)
            .HasColumnType("date").IsRequired();
        builder.HasMany(e => e.Locations)
            .WithOne(e => e.League)
            .HasForeignKey(e => e.LeagueId);
        
    }
}