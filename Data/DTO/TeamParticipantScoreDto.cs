using Data.Model;

namespace Data.DTO;

public class TeamParticipantScoreDto
{
    public int ParticipantId { get; set; }
    public ScoreDto Score { get; set; }

    public static TeamParticipantScoreDto FromEntity(TeamParticipantScore teamParticipantScore)
    {
        return new TeamParticipantScoreDto
        {
            ParticipantId = teamParticipantScore.ParticipantId,
            Score = ScoreDto.FromEntity(teamParticipantScore.Score)
        };
    }
}