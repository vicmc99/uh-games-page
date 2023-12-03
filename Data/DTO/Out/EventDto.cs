namespace Data.DTO.Out;

public class EventDto
{
    public int Id { get; set; }
    public string Type { get; set; }
    public DateTime DateTime { get; set; }
    public LocationDto Location { get; set; }

    // type = "Composed"
    public IEnumerable<ComposedTeamDto> ComposedTeams { get; set; }
    public IEnumerable<TeamCompositionScoreDto> CompositionScores { get; set; }

    // type = "ParticipantScored"
    public IEnumerable<NormalTeamDto> ParticipantScoredTeams { get; set; }
    public IEnumerable<TeamParticipantScoreDto> ParticipantScores { get; set; }

    // type = "TeamScored"
    public IEnumerable<TeamScoreDto> TeamScores { get; set; }

    // type = "MatchEvent"
    public IEnumerable<NormalTeamDto> MatchEventTeams { get; set; }
    public IEnumerable<MatchDto> Matches { get; set; }
}