// ReSharper disable InconsistentNaming

using Data.Model;

namespace Data.DTO;

public abstract class EventDTO
{
    public string Session { get; set; }
    public string Type { get; set; }
    public string Status { get; set; }
    public string Location { get; set; }
    public string Stage { get; set; }
    public bool Gender { get; set; }

    //TODO: Implement details
}

public class EventWithTeamScoredDTO : EventDTO
{
    public TeamScored[] Team;
}

public class EventWithParticipantScoredDTO : EventDTO
{
    public TeamWithParticipantScored[] Team;
}