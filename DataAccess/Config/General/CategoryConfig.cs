using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config;

public class CategoryConfig:IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasMany(e => e.Sports)
            .WithOne(e => e.Category)
            .HasForeignKey(e => e.CategoryId);
    }
}