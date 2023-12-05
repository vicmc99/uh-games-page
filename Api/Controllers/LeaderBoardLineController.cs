using Data.DTO.In;
using Microsoft.AspNetCore.Mvc;
using Services.LeaderBoardLineService;

namespace Api.Controllers;

public class LeaderBoardLineController:ControllerBase
{
    private readonly ILeaderBoardLineService _leaderboardLineService;
    private readonly ILogger<LeaderboardController> _logger;

    public LeaderBoardLineController(ILogger<LeaderboardController> logger, ILeaderBoardLineService leaderboardLineService)
    {
        _logger = logger;
        _leaderboardLineService = leaderboardLineService;
    }
/*
    [HttpGet]
    public LeaderboardDto Get([FromQuery] int year)
    {
        return _leaderboardLineService.Get(year);
    }
*/
    [HttpPost]
    public void Post([FromBody] CreateLeaderBoardLineDto createLeaderboardDto)
    {
       
            _leaderboardLineService.PostLeaderBoardLine(createLeaderboardDto);
        
        
    }
    
}