using Data.DTO.In;
using Microsoft.AspNetCore.Mvc;
using Services.Domain;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;
    private readonly ILogger<EventsController> _logger;

    public EventsController(ILogger<EventsController> logger, IEventService eventService)
    {
        _logger = logger;
        _eventService = eventService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromForm] CreateEventDto createEventDto)
    {
        var newEventId = await _eventService.PostEvent(createEventDto);
        var newEvent = await _eventService.GetEvent(newEventId);
        return CreatedAtAction(nameof(Get), new { id = newEventId }, newEvent);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var events = await _eventService.GetAllEvents();
        return Ok(events);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var eventDto = await _eventService.GetEvent(id);
        if (eventDto != null)
            return Ok(eventDto);
        return NotFound();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromForm] CreateEventDto updateEventDto)
    {
        var eventDto = await _eventService.GetEvent(id);
        if (eventDto == null)
            return NotFound();
        await _eventService.UpdateEvent(id, updateEventDto);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eventDto = await _eventService.GetEvent(id);
        if (eventDto == null)
            return NotFound();
        await _eventService.DeleteEvent(id);
        return NoContent();
    }
}