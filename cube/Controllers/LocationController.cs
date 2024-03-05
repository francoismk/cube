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

    [HttpPost]
    public IActionResult CreateLocation([FromBody] LocationCreateDTO locationDto)
    {
        try
        {
            var createdLocation = _locationService.CreateLocation(locationDto);
            if (createdLocation == null)
            {
                return BadRequest("Impossible de créer le site.");
            }
            return CreatedAtAction(nameof(CreateLocation), new { id = createdLocation.Id }, locationDto);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
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
        var locationDto = _locationService.GetLocationById(id);
        if (locationDto == null)
        {
            return NotFound($"Aucun site trouvé avec l'ID {id}.");
        }
        return Ok(locationDto);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, [FromBody] LocationUpdateDTO locationDto)
    {
        var updatedLocation = _locationService.UpdateLocation(id, locationDto);
        if (updatedLocation == null)
        {
            return BadRequest("Impossible de modifier cet employé.");
        }
        return Ok(locationDto);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteLocation(int id)
    {
        bool success = _locationService.DeleteLocation(id);
        if (!success)
        {
            return BadRequest("La localisation ne peut pas être supprimée car elle contient des employés ou elle n'existe pas.");
        }
        return Ok("Suppresion du site OK");
    }
}
