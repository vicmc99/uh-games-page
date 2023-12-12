using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config;

public class GroupConfig:IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
//Complete
        builder.HasIndex(e => new { e.LeagueId, e.Round }).IsUnique(true);
        builder.Property(e => e.Round).IsRequired();
       
    }
}