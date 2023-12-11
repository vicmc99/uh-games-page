using Data.DTO.In;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Domain;

namespace Api.Controllers;

[Route("api/[controller]")]
public class SportModalitiesController : ControllerBase
{
    private readonly ILogger<SportModalitiesController> _logger;
    private readonly ISportModalityService _sportModalityService;

    public SportModalitiesController(ILogger<SportModalitiesController> logger,
        ISportModalityService sportModalityService)
    {
        _logger = logger;
        _sportModalityService = sportModalityService;
    }

    [Authorize(Roles = "Admin, Moderator")]
    [HttpPost]
    public async Task<IActionResult> Post([FromForm] CreateSportModalityDto createSportModalityDto)
    {
        var newSportModalityId = await _sportModalityService.PostSportModality(createSportModalityDto);
        if (newSportModalityId == -1)
            return BadRequest();
        var newSportModality = await _sportModalityService.GetSportModality(newSportModalityId);
        return CreatedAtAction(nameof(Get), new { id = newSportModalityId }, newSportModality);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var sportModality = await _sportModalityService.GetSportModality(id);
        if (sportModality != null)
            return Ok(sportModality);
        return NotFound();
    }

    [Authorize(Roles = "Admin, Moderator")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromForm] CreateSportModalityDto updateSportModalityDto)
    {
        var sportModality = await _sportModalityService.GetSportModality(id);
        if (sportModality == null)
            return NotFound();
        await _sportModalityService.UpdateSportModality(id, updateSportModalityDto);
        return NoContent();
    }

    [Authorize(Roles = "Admin, Moderator")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var sportModality = await _sportModalityService.GetSportModality(id);
        if (sportModality == null)
            return NotFound();
        await _sportModalityService.DeleteSportModality(id);
        return NoContent();
    }
}