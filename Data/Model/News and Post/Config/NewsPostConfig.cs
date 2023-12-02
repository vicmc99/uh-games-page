using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Model.Config;

public class NewsPostConfig:IEntityTypeConfiguration<NewsPost>
{
    public void Configure(EntityTypeBuilder<NewsPost> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.PostTitle).IsRequired();
        builder.Property(e => e.PostDate).HasColumnType("date")
            .IsRequired();
        builder.HasOne<Journalist>(e => e.Journalist)
            .WithMany(e => e.NewsPosts)
            .HasForeignKey(e => e.Id);
//TODO:Descomentar despues de hacer las tablas de eventos
        /*  builder.HasOne<Event>(e => e.RelatedEvent)
              .WithMany(e => e.NewsPosts)
              .HasForeignKey(e => e.RelatedEventId);
          */
        builder.HasMany<Fragment>(e => e.fragments)
            .WithOne(e => e.NewsPost)
            .HasForeignKey(e => e.Id);
        builder.HasMany<PostComment>(e => e.Coments)
            .WithOne(e => e.NewsPost)
            .HasForeignKey(e => e.NewsPostId);
        

    }
}