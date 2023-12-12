using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config;

public class FacultyConfig:IEntityTypeConfiguration<Faculty>
{
    public void Configure(EntityTypeBuilder<Faculty> builder)
    {
        //Name key
        builder.Property(e => e.Name).IsRequired(true);
        builder.HasIndex(e => e.Name).IsUnique(true);
         // Acronim key   
        builder.Property(e => e.Acronym).IsRequired(true);
        builder.HasIndex(e=>e.Acronym).IsUnique(true);
        //Relations

        builder
            .HasMany(f => f.Majors)
            .WithOne(m => m.Faculty)
            .HasForeignKey(m => m.FacultyId).IsRequired();
 
       builder
            .HasMany(f => f.Representatives)
            .WithOne(r => r.Faculty)
            .HasForeignKey(r => r.FacultyId).IsRequired();
    }
}

