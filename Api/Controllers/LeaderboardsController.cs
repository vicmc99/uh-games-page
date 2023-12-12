
using Data.DTO.In;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Domain;

namespace Api.Controllers
{
    /// <summary>
    /// Controller for managing leaderboards.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class LeaderboardsController : ControllerBase
    {
        private readonly ILeaderboardService _leaderboardService;
        private readonly ILogger<LeaderboardsController> _logger;

        /// <summary>
        /// Constructor for LeaderboardsController.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="leaderboardService">The leaderboard service.</param>
        public LeaderboardsController(ILogger<LeaderboardsController> logger, ILeaderboardService leaderboardService)
        {
            _logger = logger;
            _leaderboardService = leaderboardService;
        }

        /// <summary>
        /// Method for creating a leaderboard.
        /// </summary>
        /// <param name="createLeaderboardDto">The leaderboard creation model.</param>
        /// <returns>A result indicating whether the creation was successful or not.</returns>
        [Authorize(Roles = "Admin, Moderator")]
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateLeaderboardDto createLeaderboardDto)
        {
            var existingLeaderboard = await _leaderboardService.GetLeaderboard(createLeaderboardDto.Year);
            if (existingLeaderboard != null)
                return BadRequest("The leaderboard already exists");

            var leaderboardId = _leaderboardService.PostLeaderboard(createLeaderboardDto);
            return CreatedAtAction(nameof(Post), new { id = leaderboardId },
                createLeaderboardDto);
        }

        /// <summary>
        /// Method for retrieving a leaderboard.
        /// </summary>
        /// <param name="id">The id of the leaderboard.</param>
        /// <returns>The leaderboard if found, otherwise NotFound.</returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var leaderboard = await _leaderboardService.GetLeaderboard(id);
            if (leaderboard == null) return NotFound();
            return Ok(leaderboard);
        }

        /// <summary>
        /// Method for updating a leaderboard.
        /// </summary>
        /// <param name="id">The id of the leaderboard.</param>
        /// <param name="createLeaderboardDto">The leaderboard update model.</param>
        /// <returns>A result indicating whether the update was successful or not.</returns>
        [Authorize(Roles = "Admin, Moderator")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromForm] CreateLeaderboardDto createLeaderboardDto)
        {
            var leaderboard = await _leaderboardService.GetLeaderboard(id);
            if (leaderboard == null) return NotFound();
            await _leaderboardService.UpdateLeaderboard(id, createLeaderboardDto);
            return NoContent();
        }

        /// <summary>
        /// Method for deleting a leaderboard.
        /// </summary>
        /// <param name="id">The id of the leaderboard.</param>
        /// <returns>A result indicating whether the deletion was successful or not.</returns>
        [Authorize(Roles = "Admin, Moderator")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var faculty = await _leaderboardService.GetLeaderboard(id);
            if (faculty == null) return NotFound();
            await _leaderboardService.DeleteLeaderboard(id);
            return NoContent();
        }
    }
}
