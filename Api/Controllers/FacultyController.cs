using Data.DTO.In;
using Data.DTO.Out;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Domain;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FacultyController : ControllerBase
{
    private readonly IFacultyService _facultyService;
    private readonly ILogger<FacultyController> _logger;

    public FacultyController(ILogger<FacultyController> logger, IFacultyService facultyService)
    {
        _logger = logger;
        _facultyService = facultyService;
    }


    [HttpGet]
    public IEnumerable<FacultyDto> Get([FromQuery] int year, [FromQuery] int id = -1)
    {
        if (id == -1) return _facultyService.GetAllFaculties(year);

        var facultyDtos = new FacultyDto[1];
        facultyDtos[0] = _facultyService.Get(id, year);
        return facultyDtos;
    }

    [HttpPost]
    public void Post([FromBody] CreateFacultyDto createFacultyDto)
    {
        try
        {
            if (_facultyService.CheckFaculty(createFacultyDto))
            {
                throw new ExceptionControllers("The faculty alredy exists",new Exception("400"));
            }
            _facultyService.PostFaculty(createFacultyDto);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
           
        }
        
    }

   
    
}