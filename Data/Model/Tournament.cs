namespace Data.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Tournament
{
    public int Id {get; set;}
    public DateTime StartDate {get; set;}
    public DateTime EndDate {get; set;}
    //TODO: {StartDate,EndDate,Rounds} is unique???
    public IEnumerable<Location> Locations {get; set;}
    public int Rounds;

}