using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Services.Domain;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeaderboardController : ControllerBase
{
    private readonly ILeaderboardService _leaderboardService;
    private readonly ILogger<LeaderboardController> _logger;

    public LeaderboardController(ILogger<LeaderboardController> logger, ILeaderboardService leaderboardService)
    {
        _logger = logger;
        _leaderboardService = leaderboardService;
    }

    [HttpGet("{year}")]
    public LeaderboardDto Get(int year)
    {
        return _leaderboardService.Get(year);
    }
}