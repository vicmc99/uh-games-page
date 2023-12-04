namespace Data.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Event
{
  
    public int Id { get; set; }
    public DateTime DateTime { get; set; }

    public int LocationId { get; set; }
    public Location Location { get; set; }
    
    public string Type { get; set; }
    
    public ICollection<NewsPost>NewsPosts { get; set; }
}