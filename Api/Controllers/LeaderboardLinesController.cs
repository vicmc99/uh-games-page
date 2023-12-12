﻿using Data.DTO.In;
using Microsoft.AspNetCore.Authorization;
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

    [Authorize(Roles = "Admin, Moderator")]
    [HttpPost]
    public async Task<IActionResult> Post([FromForm] CreateLeaderBoardLineDto createLeaderboardLineDto)
    {
        var leaderboardId = await _leaderboardLineService.PostLeaderboardLine(createLeaderboardLineDto);
        return CreatedAtAction(nameof(Post), new { id = leaderboardId },
            createLeaderboardLineDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var leaderboardLineDto = await _leaderboardLineService.GetLeaderboardLine(id);
        if (leaderboardLineDto == null) return NotFound();
        return Ok(leaderboardLineDto);
    }

    [Authorize(Roles = "Admin, Moderator")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromForm] CreateLeaderBoardLineDto createLeaderboardLineDto)
    {
        var leaderboard = await _leaderboardLineService.GetLeaderboardLine(id);
        if (leaderboard == null) return NotFound();
        await _leaderboardLineService.UpdateLeaderboardLine(id, createLeaderboardLineDto);
        return NoContent();
    }

    [Authorize(Roles = "Admin, Moderator")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var faculty = await _leaderboardLineService.GetLeaderboardLine(id);
        if (faculty == null) return NotFound();
        await _leaderboardLineService.DeleteLeaderboardLine(id);
        return NoContent();
    }
}