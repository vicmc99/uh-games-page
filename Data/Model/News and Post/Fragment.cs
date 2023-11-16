namespace Data.Model;
using System.ComponentModel.DataAnnotations;
public class Fragment
{
    public int Id { get; set; }
    [ScaffoldColumn(true)]
    [StringLength(2000, ErrorMessage = "The fragment value cannot exceed 2000 characters. ")]
    public string fragment { get; set; }
    
    public NewsPost NewsPost { get; set; }
}