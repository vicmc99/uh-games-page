using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config;

public class GroupLineConfig:IEntityTypeConfiguration<GroupLine>
{
    public void Configure(EntityTypeBuilder<GroupLine> builder)
    {
        builder
            .HasKey(gl => new { gl.GroupId, gl.TeamId, gl.AthleteId });

        builder
            .HasOne(gl => gl.Group)
            .WithMany()
            .HasForeignKey(gl => gl.GroupId);

        builder
            .HasOne(gl => gl.Athlete)
            .WithMany()
            .HasForeignKey(gl => gl.AthleteId);

        builder
            .HasOne(gl => gl.Team)
            .WithMany()
            .HasForeignKey(gl => gl.TeamId);

    }
}