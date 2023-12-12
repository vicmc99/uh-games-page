
using Data.DTO.In;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.MajorsService;

namespace Api.Controllers
{
    /// <summary>
    /// Controller for managing majors.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MajorsController : ControllerBase
    {
        private readonly ILogger<MajorsController> _logger;
        private readonly IMajorsService _majorsService;

        /// <summary>
        /// Constructor for MajorsController.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="majorsService">The majors service.</param>
        public MajorsController(ILogger<MajorsController> logger, IMajorsService majorsService)
        {
            _logger = logger;
            _majorsService = majorsService;
        }

        /// <summary>
        /// Method for creating a major.
        /// </summary>
        /// <param name="majorDto">The major creation model.</param>
        /// <returns>A result indicating whether the creation was successful or not.</returns>
        [Authorize(Roles = "Admin, Moderator")]
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateMajorDto majorDto)
        {
            var majorId = await _majorsService.PostMajor(majorDto);
            var newMajor = await _majorsService.GetMajor(majorId);
            return CreatedAtAction(nameof(Get), new { id = majorId }, newMajor);
        }

        /// <summary>
        /// Method for retrieving all majors.
        /// </summary>
        /// <param name="facultyId">The id of the faculty.</param>
        /// <returns>A list of all majors.</returns>
        [HttpGet]
        public async Task<IActionResult> GetMajors([FromQuery] int facultyId)
        {
            var majors = await _majorsService.GetMajors(facultyId);
            return Ok(majors);
        }

        /// <summary>
        /// Method for retrieving a major.
        /// </summary>
        /// <param name="id">The id of the major.</param>
        /// <returns>The major if found, otherwise NotFound.</returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var majorDto = await _majorsService.GetMajor(id);
            if (majorDto != null)
                return Ok(majorDto);
            return NotFound();
        }

        /// <summary>
        /// Method for updating a major.
        /// </summary>
        /// <param name="id">The id of the major.</param>
        /// <param name="majorDto">The major update model.</param>
        /// <returns>A result indicating whether the update was successful or not.</returns>
        [Authorize(Roles = "Admin, Moderator")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromForm] CreateMajorDto majorDto)
        {
            var major = await _majorsService.GetMajor(id);
            if (major == null)
                return NotFound();
            await _majorsService.UpdateMajor(id, majorDto);
            return NoContent();
        }

        /// <summary>
        /// Method for deleting a major.
        /// </summary>
        /// <param name="id">The id of the major.</param>
        /// <returns>A result indicating whether the deletion was successful or not.</returns>
        [Authorize(Roles = "Admin, Moderator")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var majorDto = await _majorsService.GetMajor(id);
            if (majorDto == null)
                return NotFound();
            await _majorsService.DeleteMajor(id);
            return NoContent();
        }
    }
}
