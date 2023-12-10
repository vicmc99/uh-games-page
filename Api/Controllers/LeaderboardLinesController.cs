using Data.DTO.In;
using Microsoft.AspNetCore.Mvc;
using Services.LeaderBoardLineService;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeaderboardLinesController : ControllerBase
{
    private readonly ILeaderBoardLineService _leaderboardLineService;
    private readonly ILogger<LeaderboardsController> _logger;

    public LeaderboardLinesController(ILogger<LeaderboardsController> logger,
        ILeaderBoardLineService leaderboardLineService)
    {
        _logger = logger;
        _leaderboardLineService = leaderboardLineService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return await _leaderboardLineService.GetLeaderboardLine(id) != null
            ? Ok(_leaderboardLineService.GetLeaderboardLine(id))
            : NotFound();
    }

    [HttpPost]
    public Task<IActionResult> Post([FromBody] CreateLeaderBoardLineDto createLeaderboardLineDto)
    {
        var leaderboardId = _leaderboardLineService.PostLeaderboardLine(createLeaderboardLineDto);
        return Task.FromResult<IActionResult>(CreatedAtAction(nameof(Get), new { id = leaderboardId },
            createLeaderboardLineDto));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromForm] CreateLeaderBoardLineDto createLeaderboardLineDto)
    {
        var leaderboard = await _leaderboardLineService.GetLeaderboardLine(id);
        if (leaderboard == null) return NotFound();
        await _leaderboardLineService.UpdateLeaderboardLine(id, createLeaderboardLineDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var faculty = await _leaderboardLineService.GetLeaderboardLine(id);
        if (faculty == null) return NotFound();
        await _leaderboardLineService.DeleteLeaderboardLine(id);
        return NoContent();
    }
}