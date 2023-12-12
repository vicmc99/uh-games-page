using Data.DTO.In;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Domain;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FacultiesController : ControllerBase
{
    private readonly IFacultyService _facultyService;
    private readonly ILogger<FacultiesController> _logger;

    public FacultiesController(ILogger<FacultiesController> logger, IFacultyService facultyService)
    {
        _logger = logger;
        _facultyService = facultyService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromForm] CreateFacultyDto createFacultyDto)
    {
        if (!User.IsInRole("Admin") && !User.IsInRole("Moderator")) return Unauthorized();
        if (_facultyService.CheckFaculty(createFacultyDto)) return BadRequest("The faculty already exists");
        var facultyId = await _facultyService.PostFaculty(createFacultyDto);
        return CreatedAtAction(nameof(Get), new { id = facultyId }, createFacultyDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var faculties = await _facultyService.GetAllFaculties();
        return Ok(faculties);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var faculty = await _facultyService.GetFaculty(id);
        if (faculty != null)
            return Ok(faculty);
        return NotFound();
    }

    [HttpGet("{id:int}/photo")]
    public async Task<IActionResult> GetImage(int id)
    {
        var (image, mimeType) = await _facultyService.GetFacultyImage(id);

        if (image != null) return File(image, mimeType!);

        return NotFound();
    }

    [Authorize(Roles = "Admin, Moderator")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromForm] CreateFacultyDto updateFacultyDto)
    {
        var faculty = await _facultyService.GetFaculty(id);
        if (faculty == null) return NotFound();
        await _facultyService.UpdateFaculty(id, updateFacultyDto);
        return NoContent();
    }

    [Authorize(Roles = "Admin, Moderator")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var faculty = await _facultyService.GetFaculty(id);
        if (faculty == null) return NotFound();
        await _facultyService.DeleteFaculty(id);
        return NoContent();
    }
}