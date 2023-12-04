namespace Data.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Location
{
    public int Id {get; set;}
    
    public int LeagueId { get; set; }
    public League League { get; set; }
    public string Name {get; set;}
    public string Address {get; set;}
    public string GoogleMapsURL {get; set;}
}