namespace Data.DTO.In;

public class CreateEventDto
{
    public DateTime DateTime { get; set; }
    public int LocationId { get; set; }
    public string Type { get; set; }
    public string SportName { get; set; }
    public string DisciplineName { get; set; }

    public IEnumerable<int> TeamIds { get; set; }
    public IEnumerable<int> ComposedTeamIds { get; set; }
    public IEnumerable<int> SubstituteIds { get; set; }

    public IEnumerable<CreateIdScoreDto> TeamScores { get; set; }
    public IEnumerable<int> TeamEventTeamParticipantIds { get; set; }

    public IEnumerable<CreateMatchDto> Matches { get; set; }

    public IEnumerable<CreateIdScoreDto> CompositionScores { get; set; }

    public IEnumerable<CreateIdScoreDto> ParticipantScores { get; set; }
}