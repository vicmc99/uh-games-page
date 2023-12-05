using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config;

public class TeamCompositionConfig:IEntityTypeConfiguration<TeamComposition>
{
    public void Configure(EntityTypeBuilder<TeamComposition> builder)
    {
        
       builder
            .HasMany(c => c.Participants)
            .WithMany();
    }
}