using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Model.Config;

public class ToReviewCommentsConfig:IEntityTypeConfiguration<ToReviewComments>
{
    public void Configure(EntityTypeBuilder<ToReviewComments> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasOne<NewsPost>(e => e.NewsPost)
            .WithMany(e => e.CommentsToReview)
            .HasForeignKey(e=>e.NewsPostId).IsRequired();
        
        builder.Property(e=>e.CommentDate).HasColumnType("date");
        builder.Property(e => e.Contents).HasMaxLength(2000);
    }
}