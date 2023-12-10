using Data.DTO.In;
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

    [HttpGet("{id}")]
    public Task<IActionResult> Get(int id)
    {
        return Task.FromResult<IActionResult>(_leaderboardService.GetLeaderboard(id) != null
            ? Ok(_leaderboardService.GetLeaderboard(id))
            : NotFound());
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateLeaderboardDto createLeaderboardDto)
    {
        if (Get(createLeaderboardDto.Year) != null)
            return BadRequest("The leaderboard already exists");
        var leaderboardId = _leaderboardService.PostLeaderboard(createLeaderboardDto);
        return CreatedAtAction(nameof(Get), new { id = leaderboardId }, createLeaderboardDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CreateLeaderboardDto createLeaderboardDto)
    {
        var leaderboard = _leaderboardService.GetLeaderboard(id);
        if (leaderboard == null) return NotFound();
        await _leaderboardService.UpdateLeaderboard(id, createLeaderboardDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var faculty = _leaderboardService.GetLeaderboard(id);
        if (faculty == null) return NotFound();
        await _leaderboardService.DeleteLeaderboard(id);
        return NoContent();
    }
}