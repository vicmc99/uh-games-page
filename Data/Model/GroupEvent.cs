namespace Data.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class GroupEvent
{
    public int Id {get; set;}
    public int GroupId {get; set;}
    public Group Group {get; set;}
    public int EventId {get; set;}
    public Event Event {get; set;}
}