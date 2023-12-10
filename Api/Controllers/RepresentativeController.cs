using Data.DTO.In;
using Microsoft.AspNetCore.Mvc;
using Services.Domain.RepresentativeService;

namespace Api.Controllers;

[Route("api/[controller]")]
public class RepresentativeController : ControllerBase
{
    private readonly ILogger<RepresentativeController> _logger;


    private readonly IRepresentativeService _representativeService;

    public RepresentativeController(ILogger<RepresentativeController> logger,
        IRepresentativeService representativeService)
    {
        _logger = logger;
        _representativeService = representativeService;
    }

    [HttpPost]
    public void Post([FromBody] CreateRepresentativeDto createRepresentativeDto)
    {
        _representativeService.PostRepresentative(createRepresentativeDto);
    }
}