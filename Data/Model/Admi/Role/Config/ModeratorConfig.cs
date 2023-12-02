using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Model.Config;

public class ModeratorConfig:IEntityTypeConfiguration<Moderator>
{
   
    public void Configure(EntityTypeBuilder<Moderator> builder)
    {
        GlobalConfig<Moderator>.MakeGlobalConfig(builder);
        /*
        builder .HasMany<PostComment>(e => e.AceptedComments)
            .WithOne(e => e.ReviewBy);
*/
    }
}