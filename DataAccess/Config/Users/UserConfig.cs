using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;
namespace Data.Model.Config;

public class UserConfig:IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        //Keys
        builder.HasKey(e => e.Id);
        
        builder.HasIndex(e => e.Email).IsUnique();
        
        //Require
        builder.Property(e => e.FirstName).IsRequired();
        
        builder.Property(e => e.LastName).IsRequired();
        
        builder.Property(e => e.BornDate).HasColumnType("date")
            .IsRequired();
        
        builder.Property(e => e.Email).IsRequired()
            .HasColumnType("nvarchar(254)");
        
        //Relations
        
        builder.HasOne(e => e.Moderator)
            .WithOne(e => e.User)
            .HasForeignKey<Moderator>(e=>e.UserId)
            .OnDelete(DeleteBehavior.Restrict).IsRequired(false);
        
        builder.HasOne(e => e.SuperUser)
            .WithOne(e => e.User)
            .HasForeignKey<SuperUser>(e=>e.UserId).IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(e => e.Journalist)
            .WithOne(e => e.User)
            .HasForeignKey<Journalist>(e=>e.UserId).IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
        
    }


}