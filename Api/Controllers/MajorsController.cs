using Data.DTO.In;
using Microsoft.AspNetCore.Mvc;
using Services.Domain;
using Services.MajorsService;

namespace Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class MajorsController
{
    private readonly IMajorsService _majorsService;
    private readonly ILogger<MajorsController> _logger;

    public MajorsController(ILogger<MajorsController> logger, IMajorsService majorsService)
    {
        _logger = logger;
        _majorsService = majorsService;
    }

    [HttpPost]
    public async void Post([FromBody] CreateMajorDto majorDto)
    {
        _majorsService.Create(majorDto);
    }
}