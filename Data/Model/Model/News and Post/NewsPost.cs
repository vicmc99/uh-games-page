using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;
using System.ComponentModel.DataAnnotations;
public class NewsPost
{
    public int Id { get; set; }
    [Required]
    public string PostTitle { get; set; }
    public DateTime PostDate { get; set; }
   //TODO: descomentar despues de las migraciones de eventos
   // public int RelatedEventId { get; set; }
   
    //public Event RelatedEvent { get; set; }
    
    public int JournalistId { get; set; }
    
    public Journalist Journalist { get; set; }
    
    public IEnumerable<ToReviewComments>CommentsToReview { get; set; }
    public IEnumerable<Fragment> fragments { get; set; } // Only fragments to 2k characters.
    public IEnumerable<PostComment> Coments { get; set; }
}