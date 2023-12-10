using Data.DTO.In;
using Microsoft.AspNetCore.Mvc;
using Services.MajorsService;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MajorsController : ControllerBase
{
    private readonly ILogger<MajorsController> _logger;
    private readonly IMajorsService _majorsService;

    public MajorsController(ILogger<MajorsController> logger, IMajorsService majorsService)
    {
        _logger = logger;
        _majorsService = majorsService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromForm] CreateMajorDto majorDto)
    {
        var majorId = await _majorsService.PostMajor(majorDto);
        var newMajor = await _majorsService.GetMajor(majorId);
        return CreatedAtAction(nameof(Get), new { id = majorId }, newMajor);
    }

    [HttpGet]
    public async Task<IActionResult> GetMajors([FromQuery] int facultyId)
    {
        var majors = await _majorsService.GetMajors(facultyId);
        return Ok(majors);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var majorDto = await _majorsService.GetMajor(id);
        if (majorDto != null)
            return Ok(majorDto);
        return NotFound();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromForm] CreateMajorDto majorDto)
    {
        var major = await _majorsService.GetMajor(id);
        if (major == null)
            return NotFound();
        await _majorsService.UpdateMajor(id, majorDto);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var majorDto = await _majorsService.GetMajor(id);
        if (majorDto == null)
            return NotFound();
        await _majorsService.DeleteMajor(id);
        return NoContent();
    }
}