using Microsoft.AspNetCore.Mvc;
using Services.Domain;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MedalsController : ControllerBase
{
    private readonly ILogger<MedalsController> _logger;
    private readonly IMedalsService medalsService;

    public MedalsController(ILogger<MedalsController> logger, IMedalsService medalsService)
    {
        _logger = logger;
        this.medalsService = medalsService;
    }

    [HttpGet]
    public object Get()
    {
        return medalsService.Get();
    }
}