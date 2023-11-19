using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Services.Domain;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FacultyController : ControllerBase
{
    private readonly IFacultyService _facultyService;
    private readonly ILogger<FacultyController> _logger;

    public FacultyController(ILogger<FacultyController> logger, IFacultyService facultyService)
    {
        _logger = logger;
        _facultyService = facultyService;
    }

    [HttpGet]
    public IEnumerable<FacultyDto> Get([FromQuery] int year)
    {
        return _facultyService.GetAllFaculties(year);
    }

    [HttpGet]
    public FacultyDto Get([FromQuery] int year, [FromQuery] int id)
    {
        return _facultyService.Get(id, year);
    }
}