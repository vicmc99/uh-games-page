using Data.DTO.In;
using Microsoft.AspNetCore.Mvc;
using Services.Domain;

namespace Api.Controllers;

[Route("api/[controller]")]
public class SportModalityController : ControllerBase
{
    private readonly ILogger<SportModalityController> _logger;
    private readonly ISportModalityService _sportModalityService;

    public SportModalityController(ILogger<SportModalityController> logger, ISportModalityService sportModalityService)
    {
        _logger = logger;
        _sportModalityService = sportModalityService;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var sportModality = await _sportModalityService.GetSportModality(id);
        if (sportModality != null)
            return Ok(sportModality);
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromForm] CreateSportModalityDto createSportModalityDto)
    {
        var newSportModalityId = await _sportModalityService.PostSportModality(createSportModalityDto);
        if (newSportModalityId == -1)
            return BadRequest();
        var newSportModality = await _sportModalityService.GetSportModality(newSportModalityId);
        return CreatedAtAction(nameof(Get), new { id = newSportModalityId }, newSportModality);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var sportModality = await _sportModalityService.GetSportModality(id);
        if (sportModality == null)
            return NotFound();
        await _sportModalityService.DeleteSportModality(id);
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromForm] CreateSportModalityDto updateSportModalityDto)
    {
        var sportModality = await _sportModalityService.GetSportModality(id);
        if (sportModality == null)
            return NotFound();
        await _sportModalityService.UpdateSportModality(id, updateSportModalityDto);
        return NoContent();
    }
}