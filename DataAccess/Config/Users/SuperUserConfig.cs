using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Model.Config;

public class SuperUserConfig:IEntityTypeConfiguration<SuperUser>
{
    public void Configure(EntityTypeBuilder<SuperUser> builder)
    {
       GlobalConfig<SuperUser>.MakeGlobalConfig(builder);
       
    }
}
