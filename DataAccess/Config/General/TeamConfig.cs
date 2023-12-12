using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config;

public class TeamConfig:IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {//Keys
        builder.HasIndex(e => e.Name).IsUnique();
        builder.Property(e => e.Name).IsRequired();
       
        //Partitions
        
        builder.HasDiscriminator<string>("TeamType")
            .HasValue<NormalTeam>("NormalTeam")
            .HasValue<ComposedTeam>("ComposedTeam");

        
    }
}