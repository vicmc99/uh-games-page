namespace Data.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Discipline
{

    public int Id { get; set; }
    public string Name { get; set; }
    public int SportId { get; set; }
    public Sport Sport { get; set; }


}