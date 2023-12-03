using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Model.Config;

public class BanUserConfig:IEntityTypeConfiguration<BanUser>
{
    public void Configure(EntityTypeBuilder<BanUser> builder)
    {
        builder.Property(e => e.NoAccessDate).HasColumnType("date")
            .IsRequired();
        //Foreign Keys
        builder.HasOne<User>(e => e.User)
            .WithMany(e => e.BanUsers)
            .HasForeignKey(e => e.UserId).IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne<SuperUser>(e => e.SuperUser)
            .WithOne(e => e.BanUser)
            .HasForeignKey<BanUser>(e => e.SuperUserId).IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Journalist>(e => e.Journalist)
            .WithOne(e => e.BanUser)
            .HasForeignKey<BanUser>(e => e.JournalistId).IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Moderator>(e => e.Moderator)
            .WithOne(e => e.BanUser)
            .HasForeignKey<BanUser>(e => e.ModeratorId).IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
        
    }
}