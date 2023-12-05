using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config;

public class GroupEventConfig:IEntityTypeConfiguration<GroupEvent>
{
    public void Configure(EntityTypeBuilder<GroupEvent> builder)
    {
        builder
            .HasKey(ge => new { ge.EventId, ge.GroupId });

        builder
            .HasOne(ge => ge.Group)
            .WithMany()
            .HasForeignKey(ge => ge.GroupId);

        builder
            .HasOne(ge => ge.Event)
            .WithMany()
            .HasForeignKey(ge => ge.EventId);
    }
}