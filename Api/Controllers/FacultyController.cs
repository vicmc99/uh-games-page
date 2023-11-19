using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Services.Domain;

namespace Api.Controllers;

[ApiController]
[Route("ap/[controller]")]
public class FacultyController : ControllerBase
{
    private readonly ILogger<FacultyController> _logger;
    private readonly IFacultyService facultyService;

   public FacultyController(ILogger<FacultyController> logger, IFacultyService facultyService)
    {
        _logger = logger;
        this.facultyService = facultyService;
    }
  /*
    [HttpGet("{id}")]
    public FacultyDto Get(int id)
    {
        return facultyService.Get(id, DateTime.Today.Year);
    }*/
   [HttpGet("{id}")]
   public async Task<ActionResult<FacultyDto>> Get(int id)
   {
      return  facultyService.Get(id, DateTime.Today.Year);
   }
}