using Data.DTO.In;
using Microsoft.AspNetCore.Mvc;
using Services.Domain.RepresentativeService;

namespace Api.Controllers;

[Route("api/[controller]")]
public class RepresentativesController : ControllerBase
{
    private readonly ILogger<RepresentativesController> _logger;


    private readonly IRepresentativeService _representativeService;

    public RepresentativesController(ILogger<RepresentativesController> logger,
        IRepresentativeService representativeService)
    {
        _logger = logger;
        _representativeService = representativeService;
    }

    [HttpPost]
    public void Post([FromForm] CreateRepresentativeDto createRepresentativeDto)
    {
        _representativeService.PostRepresentative(createRepresentativeDto);
    }
}