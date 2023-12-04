using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

public class TournamentEvent
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int TournamentId { get; set; }
    public Tournament Tournament { get; set; }

    public int EventId { get; set; }
    public Event Event { get; set; }

    public int Round { get; set; }
}