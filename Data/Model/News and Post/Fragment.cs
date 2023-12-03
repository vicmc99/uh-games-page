using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;
using System.ComponentModel.DataAnnotations;
public class Fragment
{
    public int Id { get; set; }
   
    public string fragment { get; set; }
    
    public int NewsPostId { get; set; }
 
    public NewsPost NewsPost { get; set; }
}