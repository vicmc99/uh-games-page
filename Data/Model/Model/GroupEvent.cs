namespace Data.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class GroupEvent
{
    public int Id {get; set;}
    [ForeignKey("Group")]
    public int GroupId {get; set;}
    [Required]
    public Group Group {get; set;}
    [ForeignKey("Event")]
    public int EventId {get; set;}
    [Required]
    public Event Event {get; set;}
}