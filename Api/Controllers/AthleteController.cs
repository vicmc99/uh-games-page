using Data.DTO.In;
using Data.DTO.Out;
using Microsoft.AspNetCore.Mvc;
using Services.Domain;

namespace Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AthleteController:ControllerBase
{
    private readonly IAthleteService _athleteService;
    private readonly ILogger<AthleteController> _logger;

    public AthleteController(ILogger<AthleteController> logger, IAthleteService athleteService)
    {
        _logger = logger;
        _athleteService = athleteService;
    }

    [HttpPost]
    public void Post([FromBody] CreateAthleteDto createAthleteDto)
    {
        _athleteService.PostAthlete(createAthleteDto);
    }
}