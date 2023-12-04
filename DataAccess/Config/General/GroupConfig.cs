using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config;

public class GroupConfig:IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasOne(e => e.GroupEvent)
            .WithOne(e => e.Group)
            .HasForeignKey<GroupEvent>(e => e.GroupId);
        builder.HasOne<GroupLine>().WithOne(e => e.Group)
            .HasForeignKey<GroupLine>(e => e.GroupId);
        
    }
}