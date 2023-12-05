using Data.DTO.In;

namespace Services.LeaderBoardLineService;

public interface ILeaderBoardLineService
{
    public void PostLeaderBoardLine(CreateLeaderBoardLineDto createLeaderBoardLineDto);
}