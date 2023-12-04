namespace Data.DTO.In;

public class CreateEventDto
{
    public DateTime DateTime { get; set; }
    public int LocationId { get; set; }
    public string Type { get; set; }
}

public class CreateMatchEventDto : CreateEventDto
{
    public IEnumerable<int> TeamIds { get; set; }
    public IEnumerable<int> MatchIds { get; set; }
}

public class CreateTeamEventDto : CreateEventDto
{
    public IEnumerable<int> TeamParticipantsId { get; set; }
    public IEnumerable<int> TeamSubstitutesId { get; set; }
    public IEnumerable<int> TeamId { get; set; }
    public IEnumerable<int> ParticipantId { get; set; }
}

public class CreateComposedTeamsEventDto : CreateEventDto
{
    public IEnumerable<int> ComposedTeamsId { get; set; }
    public IEnumerable<int> CompositionId { get; set; }
}

public class ParticipantScoredEventDto : CreateEventDto
{
    public IEnumerable<int> ParticipantScoredTeamsId { get; set; }
    public IEnumerable<int> ParticipantScoresId { get; set; }
    public IEnumerable<int> TeamSubstitutesId { get; set; }
}