
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Domain;

namespace Api.Controllers
{
    /// <summary>
    /// Controller for managing events.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly ILogger<EventsController> _logger;

        /// <summary>
        /// Constructor for EventsController.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="eventService">The event service.</param>
        public EventsController(ILogger<EventsController> logger, IEventService eventService)
        {
            _logger = logger;
            _eventService = eventService;
        }

        /// <summary>
        /// Method for creating an event.
        /// </summary>
        /// <param name="createEventDto">The event creation model.</param>
        /// <returns>A result indicating whether the creation was successful or not.</returns>
        //[Authorize(Roles = "Admin, Moderator")]
        //[HttpPost]
        //public async Task<IActionResult> Post([FromForm] CreateEventDto createEventDto)
        //{
        //    var newEventId = await _eventService.PostEvent(createEventDto);
        //    var newEvent = await _eventService.GetEvent(newEventId);
        //    return CreatedAtAction(nameof(Get), new { id = newEventId }, newEvent);
        //}

        /// <summary>
        /// Method for retrieving all events.
        /// </summary>
        /// <returns>A list of all events.</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var events = await _eventService.GetAllEvents();
            return Ok(events);
        }

        /// <summary>
        /// Method for retrieving an event.
        /// </summary>
        /// <param name="id">The id of the event.</param>
        /// <returns>The event if found, otherwise NotFound.</returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var eventDto = await _eventService.GetEvent(id);
            if (eventDto != null)
                return Ok(eventDto);
            return NotFound();
        }

        /// <summary>
        /// Method for updating an event.
        /// </summary>
        /// <param name="id">The id of the event.</param>
        /// <param name="updateEventDto">The event update model.</param>
        /// <returns>A result indicating whether the update was successful or not.</returns>
        //[Authorize(Roles = "Admin, Moderator")]
        //[HttpPut("{id:int}")]
        //public async Task<IActionResult> Update(int id, [FromForm] CreateEventDto updateEventDto)
        //{
        //    var eventDto = await _eventService.GetEvent(id);
        //    if (eventDto == null)
        //        return NotFound();
        //    await _eventService.UpdateEvent(id, updateEventDto);
        //    return NoContent();
        //}

        /// <summary>
        /// Method for deleting an event.
        /// </summary>
        /// <param name="id">The id of the event.</param>
        /// <returns>A result indicating whether the deletion was successful or not.</returns>
        [Authorize(Roles = "Admin, Moderator")]
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
}
