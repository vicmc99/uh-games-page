using System.Runtime.InteropServices.JavaScript;
using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Services.Domain;

namespace Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AddFacultyController:ControllerBase
{
    private readonly ILogger<FacultyController> _logger;
    private readonly IFacultyService facultyService;

    public AddFacultyController(ILogger<FacultyController> logger, IFacultyService facultyService)
    {
        _logger = logger;
        this.facultyService = facultyService;
    }

   
  /*  
    [HttpPost]
    public async Task<ActionResult<FacultyDto>> CreateTodoItem(FacultyDto facultyDto)
    {



        return CreatedAtAction(
            nameof(GetFaculty),
            new {id = facultyDto.Id},
            facultyDto);
    }*/

    
}