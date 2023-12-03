using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Model.Config;

public class FragmentConfig:IEntityTypeConfiguration<Fragment>
{
    public void Configure(EntityTypeBuilder<Fragment> builder)
    {
        builder.HasKey(e => e.Id);
       builder.Property(e => e.fragment)
            .HasMaxLength(2000)
            .IsRequired();

      
}
}