
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Data.Model;

public class Category
{
   
    public int Id {get; set;}
    public string Name {get; set;}
    public IEnumerable<Sport> Sports {get; set;}
}