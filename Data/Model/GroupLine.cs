namespace Data.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class GroupLine
{
    public int Id {get; set;}
    
    public int GroupId {get; set;}
  
    public Group Group {get; set;}
    
    public int TeamId {get; set;}
  
    public Team Team {get; set;}
   
    public int AthleteId {get; set;}
  
    public Athlete Athlete {get; set;}
    public int Position {get; set;}
    public string Statistics {get; set;}
    public string Status {get; set;}
    public int Round {get; set;}
}
