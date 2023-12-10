using Data.DTO.In;
using Microsoft.AspNetCore.Mvc;
using Services.Domain.RepresentativeService;

namespace Api.Controllers;

[Route("api/[controller]")]
public class RepresentativesController : ControllerBase
{
    private readonly ILogger<RepresentativesController> _logger;


    private readonly IRepresentativeService _representativeService;

    public RepresentativesController(ILogger<RepresentativesController> logger,
        IRepresentativeService representativeService)
    {
        _logger = logger;
        _representativeService = representativeService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromForm] CreateRepresentativeDto createRepresentativeDto)
    {
        var representativeId = await _representativeService.PostRepresentative(createRepresentativeDto);

        return CreatedAtAction(nameof(Post), new { id = representativeId }, null);
    }

    [HttpGet("{facultyId:int}")]
    public Task<IActionResult> GetFromFaculty(int facultyId)
    {
        var representatives = _representativeService.GetRepresentatives(facultyId);
        return representatives.IsFaulted
            ? Task.FromResult<IActionResult>(BadRequest(representatives.Exception?.Message))
            : Task.FromResult<IActionResult>(Ok(representatives));
    }

    [HttpGet]
    public Task<IActionResult> Get([FromQuery] int id)
    {
        var representative = _representativeService.GetRepresentative(id);
        return representative.Result == null
            ? Task.FromResult<IActionResult>(NotFound())
            : Task.FromResult<IActionResult>(Ok(representative));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] CreateRepresentativeDto updateRepresentativeDto)
    {
        var representative = await _representativeService.GetRepresentative(id);
        if (representative == null)
            return NotFound();
        await _representativeService.UpdateRepresentative(id, updateRepresentativeDto);
        return NoContent();
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var representative = await _representativeService.GetRepresentative(id);
        if (representative == null)
            return NotFound();
        await _representativeService.DeleteRepresentative(id);
        return NoContent();
    }
}