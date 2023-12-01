namespace Data.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Event
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime DateTime { get; set; }
    //Location Key
    [ForeignKey("Location")]
    public int LocationId { get; set; }
    public Location Location { get; set; }
    
    public string Type { get; set; }
}