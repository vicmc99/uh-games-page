namespace Data.DTO.In;

public class CreateEventDto
{
    public DateTime DateTime { get; set; }
    public int LocationId { get; set; }
    public string Type { get; set; }
    public int SportModalityId { get; set; }

    // type = "MatchEvent"
    public IEnumerable<int> MatchTeamIds { get; set; }
    public IEnumerable<int> MatchIds { get; set; }

    // type = "TeamScored"
    public IEnumerable<int> TeamEventTeamIds { get; set; }
    public IEnumerable<(int, int)> TeamEventTeamSubstitutesTupleId { get; set; }

    //(TeamId, ParticipantId)
    public IEnumerable<(int, int)> TeamEventTeamParticipantTupleId { get; set; }

    // type = "Composed"
    public IEnumerable<int> ComposedTeamsId { get; set; }
    public IEnumerable<int> ComposedTeamCompositionId { get; set; }

    // type = "ParticipantScored"
    public IEnumerable<int> ParticipantScoredId { get; set; }

    public IEnumerable<(int, int)> ParticipantScoredTeamSubstitutesTupleId { get; set; }

    //(TeamId, ParticipantId)
    public IEnumerable<(int, int)> ParticipantScoredTeamParticipantTupleId { get; set; }
}