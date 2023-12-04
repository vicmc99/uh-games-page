using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;
namespace Data.Model.Config;

public class UserConfig:IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.FirstName).IsRequired();
        builder.Property(e => e.LastName).IsRequired();
        builder.Property(e => e.BornDate).HasColumnType("date")
            .IsRequired();
      /* 
        builder.HasOne(e => e.Moderator)
            .WithOne(e => e.User)
            .HasForeignKey<Moderator>();
        
        builder.HasOne(e => e.SuperUser)
            .WithOne(e => e.User)
            .HasForeignKey<SuperUser>();
        
        builder.HasOne(e => e.Journalist)
            .WithOne(e => e.User)
            .HasForeignKey<Journalist>();
        */
    }


}