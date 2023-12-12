using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config;

public class TeamConfig:IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
       /* builder.HasDiscriminator<string>("TeamType")
            .HasValue<NormalTeam>("NormalTeam")
            .HasValue<ComposedTeam>("ComposedTeam");

        builder.HasKey(e => e.Name);*/
    }
}