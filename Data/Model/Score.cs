namespace Data.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Score
{
    public int Id { get; set; }
    public float NumberScore { get; set; }

    // TODO: Add score formats for every sport
}