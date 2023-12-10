using Data.DTO.In;
using Microsoft.AspNetCore.Mvc;
using Services.Domain;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AthletesController : ControllerBase
{
    private readonly IAthleteService _athleteService;
    private readonly ILogger<AthletesController> _logger;

    public AthletesController(ILogger<AthletesController> logger, IAthleteService athleteService)
    {
        _logger = logger;
        _athleteService = athleteService;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var athlete = await _athleteService.GetAthlete(id);
        if (athlete != null)
            return Ok(athlete);
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromForm] CreateAthleteDto createAthleteDto)
    {
        var newAthleteId = await _athleteService.PostAthlete(createAthleteDto);
        if (newAthleteId == -1)
            return BadRequest();
        var newAthlete = await _athleteService.GetAthlete(newAthleteId);
        return CreatedAtAction(nameof(Get), new { id = newAthleteId }, newAthlete);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var athlete = await _athleteService.GetAthlete(id);
        if (athlete == null)
            return NotFound();
        await _athleteService.DeleteAthlete(id);
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromForm] CreateAthleteDto updateAthleteDto)
    {
        var athlete = await _athleteService.GetAthlete(id);
        if (athlete == null)
            return NotFound();
        await _athleteService.UpdateAthlete(id, updateAthleteDto);
        return NoContent();
    }
}