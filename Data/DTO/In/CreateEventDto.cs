namespace Data.DTO.In;

public class CreateEventDto
{
    public DateTime DateTime { get; set; }
    public int LocationId { get; set; }
    public string Type { get; set; }
    public int SportModalityId { get; set; }
}

public class CreateMatchEventDto : CreateEventDto
{
    public IEnumerable<int> TeamIds { get; set; }
    public IEnumerable<int> MatchIds { get; set; }
}

public class CreateTeamEventDto : CreateEventDto
{
    public IEnumerable<int> TeamIds { get; set; }
    public IEnumerable<(int, int)> TeamSubstitutesTupleId { get; set; }

    //(TeamId, ParticipantId)
    public IEnumerable<(int, int)> TeamParticipantTupleId { get; set; }
}

public class CreateComposedTeamsEventDto : CreateEventDto
{
    public IEnumerable<int> ComposedTeamsId { get; set; }
    public IEnumerable<int> CompositionId { get; set; }
}

public class CreateParticipantScoredEventDto : CreateEventDto
{
    public IEnumerable<int> ParticipantScoredId { get; set; }

    public IEnumerable<(int, int)> TeamSubstitutesTupleId { get; set; }

    //(TeamId, ParticipantId)
    public IEnumerable<(int, int)> TeamParticipantTupleId { get; set; }
}