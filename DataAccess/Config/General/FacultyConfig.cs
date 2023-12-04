using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config;

public class FacultyConfig:IEntityTypeConfiguration<Faculty>
{
    public void Configure(EntityTypeBuilder<Faculty> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).IsRequired();
        builder.HasIndex(e => e.Name).IsUnique();
        builder.Property(e => e.Acronym).IsRequired();
        builder.Property(e => e.Logo).IsRequired();
        builder.Property(e => e.Mascot).IsRequired();
        builder.Property(e => e.Logo).IsRequired();
        
        //Relations
        builder.HasMany(e => e.Majors)
            .WithOne(e => e.Faculty)
            .HasForeignKey(e => e.FacultyId).IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(e => e.Teams)
            .WithOne(e => e.Faculty)
            .HasForeignKey(e => e.FacultyId).IsRequired();

        builder.HasMany(e => e.Representatives)
            .WithOne(e => e.Faculty)
            .HasForeignKey(e => e.FacultyId)
            .IsRequired().OnDelete(DeleteBehavior.Cascade);

    }
}