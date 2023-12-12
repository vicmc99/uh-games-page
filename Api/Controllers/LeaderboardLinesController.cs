using Data.DTO.In;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.LeaderBoardLineService;

namespace Api.Controllers
{
    /// <summary>
    /// Controller for managing leaderboard lines.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class LeaderboardLinesController : ControllerBase
    {
        private readonly ILeaderBoardLineService _leaderboardLineService;
        private readonly ILogger<LeaderboardsController> _logger;

        /// <summary>
        /// Constructor for LeaderboardLinesController.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="leaderboardLineService">The leaderboard line service.</param>
        public LeaderboardLinesController(ILogger<LeaderboardsController> logger,
            ILeaderBoardLineService leaderboardLineService)
        {
            _logger = logger;
            _leaderboardLineService = leaderboardLineService;
        }

        /// <summary>
        /// Method for creating a leaderboard line.
        /// </summary>
        /// <param name="createLeaderboardLineDto">The leaderboard line creation model.</param>
        /// <returns>A result indicating whether the creation was successful or not.</returns>
        [Authorize(Roles = "Admin, Moderator")]
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateLeaderBoardLineDto createLeaderboardLineDto)
        {
            var leaderboardId = await _leaderboardLineService.PostLeaderboardLine(createLeaderboardLineDto);
            return CreatedAtAction(nameof(Post), new { id = leaderboardId },
                createLeaderboardLineDto);
        }

        /// <summary>
        /// Method for retrieving a leaderboard line.
        /// </summary>
        /// <param name="id">The id of the leaderboard line.</param>
        /// <returns>The leaderboard line if found, otherwise NotFound.</returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var leaderboardLineDto = await _leaderboardLineService.GetLeaderboardLine(id);
            if (leaderboardLineDto == null) return NotFound();
            return Ok(leaderboardLineDto);
        }

        /// <summary>
        /// Method for updating a leaderboard line.
        /// </summary>
        /// <param name="id">The id of the leaderboard line.</param>
        /// <param name="createLeaderboardLineDto">The leaderboard line update model.</param>
        /// <returns>A result indicating whether the update was successful or not.</returns>
        [Authorize(Roles = "Admin, Moderator")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromForm] CreateLeaderBoardLineDto createLeaderboardLineDto)
        {
            var leaderboard = await _leaderboardLineService.GetLeaderboardLine(id);
            if (leaderboard == null) return NotFound();
            await _leaderboardLineService.UpdateLeaderboardLine(id, createLeaderboardLineDto);
            return NoContent();
        }

        /// <summary>
        /// Method for deleting a leaderboard line.
        /// </summary>
        /// <param name="id">The id of the leaderboard line.</param>
        /// <returns>A result indicating whether the deletion was successful or not.</returns>
        [Authorize(Roles = "Admin, Moderator")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var faculty = await _leaderboardLineService.GetLeaderboardLine(id);
            if (faculty == null) return NotFound();
            await _leaderboardLineService.DeleteLeaderboardLine(id);
            return NoContent();
        }
    }
}