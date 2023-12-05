using Data.DTO.In;
using Data.DTO.Out;
using Microsoft.AspNetCore.Mvc;
using Services.Domain;
using Services.Domain.RepresentativeService;

namespace Api.Controllers;
[Route("api/[controller]")]
public class RepresentativeController: ControllerBase
{
   
   
        private readonly IRepresentativeService _representativeService;
        private readonly ILogger<RepresentativeController> _logger;

        public RepresentativeController(ILogger<RepresentativeController> logger, IRepresentativeService representativeService)
        {
            _logger = logger;
            _representativeService = representativeService;
        }

        /*[HttpGet]
        public IEnumerable<RepresentativeDto> Get()
        {
            return _eventService.Get();
        }*/

        [HttpPost]
        public void Post([FromBody] CreateRepresentativeDto createRepresentativeDto)
        {
            _representativeService.PostRepresentative(createRepresentativeDto);
            
        
        }
    
}