

using Microsoft.AspNetCore.Mvc;
using Namespace;

namespace cube;
[ApiController]
[Route("api/[controller]")]
public class ServiceController : ControllerBase
{
  private readonly ServiceService _serviceService;

  public ServiceController(ServiceService serviceService)
  {
    _serviceService = serviceService;
  }

  [HttpGet("All")]
  public IActionResult GetAllServices()
  {
    var services = _serviceService.GetAllServicesWithLocations();
    return Ok(services);
  }

  [HttpGet("ById/{id}")]
  public IActionResult GetServiceById(int id)
  {
    var serviceDto = _serviceService.GetServiceById(id);
    if (serviceDto == null)
    {
      return NotFound($"Aucun service trouvé avec l'ID {id}.");
    }
    return Ok(serviceDto);
  }

  [HttpGet("ByLocation/{locationName}")]
  public IActionResult GetServicesByLocation(string locationName)
  {
    var services = _serviceService.GetServicesByLocationName(locationName);
    if (services == null || !services.Any())
    {
      return NotFound($"Aucun service trouvé pour la localisation {locationName}.");
    }
    return Ok(services);
  }
}

