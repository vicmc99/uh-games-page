using Data.DTO;
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
    public SportModalityDto Get(int id)
    {
        return _sportModalityService.Get(id);
    }
}