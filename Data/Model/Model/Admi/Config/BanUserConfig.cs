using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Model.Config;

public class BanUserConfig:IEntityTypeConfiguration<BanUser>
{
    public void Configure(EntityTypeBuilder<BanUser> builder)
    {
        /*
        builder.HasOne<User>(e => e.User)
            .WithMany(e => e.BanUsers)
            .HasForeignKey(e => e.UserId);
        builder.HasOne<Role>(e => e.Role)
            .WithOne(e => e.BanUser)
            .HasForeignKey<BanUser>(e => e.RoleId);
        */


    }
}