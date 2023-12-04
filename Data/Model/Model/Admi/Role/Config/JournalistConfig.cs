using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Model.Config;

public class JournalistConfig:IEntityTypeConfiguration<Journalist>
{
    public void Configure(EntityTypeBuilder<Journalist> builder)
    {
      /*  GlobalConfig<Journalist>.MakeGlobalConfig(builder);
        builder.HasKey(e => e.Id);

        builder.HasOne<User>(e => e.User)
            .WithOne(e => e.Journalist);
        
        builder
            .HasMany<NewsPost>(e => e.NewsPosts)
            .WithOne(e => e.Journalist);
        */
    }
    
}