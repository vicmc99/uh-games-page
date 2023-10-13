namespace Data.Model;

public class Team
{
    public int Id { get; set; }
    public int FacultyId { get; set; }
    public Faculty Faculty { get; set; }
    public ICollection<TeamMember> Members { get; set; }
}

public class TeamScored : Team
{
    public float Score { get; set; }
}

public class TeamWithParticipantScored : Team
{
    public float[] ScorePerMember { get; set; }
}