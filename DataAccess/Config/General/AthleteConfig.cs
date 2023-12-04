using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config;

public class AthleteConfig:IEntityTypeConfiguration<Athlete>
{
    public void Configure(EntityTypeBuilder<Athlete> builder)
    {
        builder.HasIndex(e => new { e.Name, e.Nick }).IsUnique();
        builder.Property(e => e.DateOfBirth).HasColumnType("date").IsRequired();
        builder.Property(e => e.Name).IsRequired();
        builder.Property(e => e.Nick).IsRequired();
       
    }
}