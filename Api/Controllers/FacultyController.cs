using Microsoft.AspNetCore.Mvc;
using Services.Domain;
using Data.DTO;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FacultyController : ControllerBase
{
    private readonly ILogger<FacultyController> _logger;
    private readonly IFacultyService facultyService;

    public FacultyController(ILogger<FacultyController> logger, IFacultyService facultyService)
    {
        _logger = logger;
        this.facultyService = facultyService;
    }

    [HttpGet("{id}")]
    public FacultyDTO Get(int id)
    {
        return facultyService.Get(id, DateTime.Today.Year);
    }
}
