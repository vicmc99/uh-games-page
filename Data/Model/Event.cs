using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

public class Event
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public DateTime DateTime { get; set; }

    public int LocationId { get; set; }

    public Location Location { get; set; }
    
    public int SportModalityId { get; set; }
    public Modality SportModality { get; set; }

    public string Type { get; set; }
}