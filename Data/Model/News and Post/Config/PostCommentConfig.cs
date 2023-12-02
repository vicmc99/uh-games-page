using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Model.Config;

public class PostCommentConfig:IEntityTypeConfiguration<PostComment>
{
    public void Configure(EntityTypeBuilder<PostComment> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Contents)
            .HasMaxLength(2000).IsRequired();
        builder.HasOne<NewsPost>(e => e.NewsPost)
            .WithMany(e => e.Coments)
            .HasForeignKey(e => e.NewsPostId);

        builder.HasOne<Moderator>(e => e.ReviewBy)
            .WithMany(e => e.AceptedComments)
            .HasForeignKey(e => e.ReviewById);

        builder.Property(e => e.CommentDate).HasColumnType("date");
        builder.Property(e => e.ReviewDate).HasColumnType("date");




    } 
}