using Data.DTO.In;
using Data.DTO.Out;
using Microsoft.AspNetCore.Mvc;
using Services.Domain;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventController : ControllerBase
{
    private readonly IEventService _eventService;
    private readonly ILogger<EventController> _logger;

    public EventController(ILogger<EventController> logger, IEventService eventService)
    {
        _logger = logger;
        _eventService = eventService;
    }

    [HttpGet]
    public IEnumerable<EventDto> Get()
    {
        return _eventService.Get();
    }

    [HttpPost]
    public void Post([FromBody] CreateEventDto createEventDto)
    {
        _eventService.PostEvent(createEventDto);
    }
}