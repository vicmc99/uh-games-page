using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class LeaderBoardLineController:ControllerBase
{
    private readonly ILeaderboarLinedService _leaderboardService;
    private readonly ILogger<LeaderboardController> _logger;

    public LeaderboardController(ILogger<LeaderboardController> logger, ILeaderboardService leaderboardService)
    {
        _logger = logger;
        _leaderboardService = leaderboardService;
    }

    [HttpGet]
    public LeaderboardDto Get([FromQuery] int year)
    {
        return _leaderboardService.Get(year);
    }

    [HttpPost]
    public void Post([FromBody] CreateLeaderboardDto createLeaderboardDto)
    {
        try
        {
            if (Get(createLeaderboardDto.Year) != null)
            {
                throw new ExceptionControllers("Leaderboard already exists", new Exception("400"));
            }
            _leaderboardService.Post(createLeaderboardDto);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }
        
    }
    
}