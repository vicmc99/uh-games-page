using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config;

public class CompetitionConfig : IEntityTypeConfiguration<Competition>
{
    public void Configure(EntityTypeBuilder<Competition> builder)
    {
        //Complete
        builder.HasIndex(e => new { e.Year,e.ModalityId }).IsUnique();
        builder.Property(e => e.Year).IsRequired();
        
    }
}