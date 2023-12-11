using Data.DTO.In;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Domain;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeaderboardsController : ControllerBase
{
    private readonly ILeaderboardService _leaderboardService;
    private readonly ILogger<LeaderboardsController> _logger;

    public LeaderboardsController(ILogger<LeaderboardsController> logger, ILeaderboardService leaderboardService)
    {
        _logger = logger;
        _leaderboardService = leaderboardService;
    }

    [Authorize(Roles = "Admin, Moderator")]
    [HttpPost]
    public async Task<IActionResult> Post([FromForm] CreateLeaderboardDto createLeaderboardDto)
    {
        var existingLeaderboard = await _leaderboardService.GetLeaderboard(createLeaderboardDto.Year);
        if (existingLeaderboard != null)
            return BadRequest("The leaderboard already exists");

        var leaderboardId = _leaderboardService.PostLeaderboard(createLeaderboardDto);
        return CreatedAtAction(nameof(Get), new { id = leaderboardId },
            createLeaderboardDto);
    }

    [HttpGet("{year:int}")]
    public async Task<IActionResult> Get(int year)
    {
        var leaderboard = await _leaderboardService.GetLeaderboard(year);
        if (leaderboard == null) return NotFound();
        return Ok(leaderboard);
    }

    [Authorize(Roles = "Admin, Moderator")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromForm] CreateLeaderboardDto createLeaderboardDto)
    {
        var leaderboard = await _leaderboardService.GetLeaderboard(id);
        if (leaderboard == null) return NotFound();
        await _leaderboardService.UpdateLeaderboard(id, createLeaderboardDto);
        return NoContent();
    }

    [Authorize(Roles = "Admin, Moderator")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var faculty = await _leaderboardService.GetLeaderboard(id);
        if (faculty == null) return NotFound();
        await _leaderboardService.DeleteLeaderboard(id);
        return NoContent();
    }
}