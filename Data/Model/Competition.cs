using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

public class Competition
{
    
    public int Id {get; set;}
   
    public int ModalityId {get; set;}
    public Modality Modality {get; set;}
    public int Year {get; set;}
}