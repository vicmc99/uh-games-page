using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Services.Domain;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ScheduleController : ControllerBase
{
    private readonly ILogger<ScheduleController> _logger;
    private readonly IScheduleService _scheduleService;

    public ScheduleController(ILogger<ScheduleController> logger, IScheduleService scheduleService)
    {
        _logger = logger;
        this._scheduleService = scheduleService;
    }

    [HttpGet("")]
    public EventDTO[] Get()
    {
        return _scheduleService.Get();
    }
}