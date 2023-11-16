using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Services.Domain;

namespace Api.Controllers;

[Route("api/[controller]")]
public class SportModalityController : ControllerBase
{
    private readonly ILogger<SportModalityController> _logger;
    private readonly ISportModalityService sportModalityService;

    public SportModalityController(ILogger<SportModalityController> logger, ISportModalityService sportModalityService)
    {
        _logger = logger;
        this.sportModalityService = sportModalityService;
    }

    [HttpGet("{id:int}")]
    public SportModalityDto Get(int id)
    {
        return sportModalityService.Get(id);
    }
}