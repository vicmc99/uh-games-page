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
    
    [HttpGet("{id}")]
    public Task<IActionResult> Get(int id)
    {
        return Task.FromResult<IActionResult>(_leaderboardLineService.GetLeaderboardLine(id) != null
            ? Ok(_leaderboardLineService.GetLeaderboardLine(id))
            : NotFound());
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateLeaderBoardLineDto createLeaderboardLineDto)
    {
        if (Get(createLeaderboardLineDto.Year) != null)
            return BadRequest("The leaderboard already exists");
        var leaderboardId = _leaderboardLineService.PostLeaderboardLine(createLeaderboardLineDto);
        return CreatedAtAction(nameof(Get), new { id = leaderboardId }, createLeaderboardLineDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CreateLeaderBoardLineDto createLeaderboardLineDto)
    {
        var leaderboard = _leaderboardLineService.GetLeaderboardLine(id);
        if (leaderboard == null) return NotFound();
        await _leaderboardLineService.UpdateLeaderboardLine(id, createLeaderboardLineDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var faculty = _leaderboardLineService.GetLeaderboardLine(id);
        if (faculty == null) return NotFound();
        await _leaderboardLineService.DeleteLeaderboardLine(id);
        return NoContent();
    }
}