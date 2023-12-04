namespace Data.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Group
{
    public int Id { get; set; }
    public int LeagueId {get; set;}
    public League League {get; set;}
    public int Round {get; set;}

    public GroupEvent GroupEvent { get; set; }


    public int GroupEventId { get; set; }
}