using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config.Teams;

public class ComposedTeamConfig:IEntityTypeConfiguration<ComposedTeam>
{
    public void Configure(EntityTypeBuilder<ComposedTeam> builder)
    {
        builder.
            HasMany(ct => ct.Compositions)
            .WithOne()
            .HasForeignKey("ComposedTeamId");
    }
}