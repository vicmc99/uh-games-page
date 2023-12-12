using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config;

public class TournamentConfig:IEntityTypeConfiguration<Tournament>
{
    public void Configure(EntityTypeBuilder<Tournament> builder)
    {
        builder.HasKey(e => new {e.StartDate,e.EndDate,e.Rounds});
        builder
            .HasMany(t => t.Locations)
            .WithMany();
    }
}