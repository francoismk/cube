using Microsoft.AspNetCore.Mvc;

namespace Namespace;



[Route("api/[controller]")]
[ApiController]
public class LocationController : ControllerBase
{
    private readonly LocationService _locationService;

    public LocationController(LocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet("All")]
    public IActionResult GetAll()
    {
        var LocationDto = _locationService.GetAllWithService();
        if (LocationDto == null)
        {
            return NotFound($"Aucun site trouvé");
        }
        return Ok(LocationDto);
    }

    [HttpGet("ById/{id}")]
    public IActionResult GetLocationById(int id)
    {
        var locationDto = _locationService.GetServiceById(id);
        if (locationDto == null)
        {
            return NotFound($"Aucun site trouvé avec l'ID {id}.");
        }
        return Ok(locationDto);
    }
}
