using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Model.Config;



public static class GlobalConfig <T> where T : Role
{
    public static void  MakeGlobalConfig(EntityTypeBuilder<T> builder)
    {

      
      builder.Property(e => e.NickName).IsRequired();
      builder.Property(e => e.Password).IsRequired();
      builder.Property(e => e.Email).IsRequired()
          .HasColumnType("nvarchar(254)");
      builder.Property(e => e.SignUpDate).HasColumnType("date")
          .IsRequired();
        builder
            .Property(e => e.Email)
            .HasColumnType("nvarchar(254)");
        
    }
}