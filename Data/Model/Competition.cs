using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

public class Competition
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int ModalityId { get; set; }
    
    public Modality Modality { get; set; }
    //TODO: la tupla {ModalityI, Year} es única???
    public int Year { get; set; }
}