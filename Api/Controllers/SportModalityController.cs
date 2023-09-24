using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Services.Domain;

namespace Api.Controllers;

[Route("api/[controller]")]
public class SportModalityController : ControllerBase
{
    private readonly ILogger<FacultyController> _logger;
    private readonly ISportModalityService sportModalityService;
 
    public SportModalityController(ILogger<FacultyController> logger, ISportModalityService sportModalityService)
    {
        _logger = logger;
        this.sportModalityService = sportModalityService;
    }

    [HttpGet("{id:int}")]
    public SportModalityDTO Get(int id)
    {
        return sportModalityService.Get(id);
    }
}