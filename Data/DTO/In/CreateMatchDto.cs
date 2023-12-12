namespace Data.DTO.In;

public class CreateMatchDto
{
    public IEnumerable<CreateIdScoreDto> MatchedParticipantsScore { get; set; }
}