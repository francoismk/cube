

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

  [HttpPost]
  public IActionResult CreateService([FromBody] ServiceCreateDTO serviceDto)
  {
    try
    {
      var createdService = _serviceService.CreateService(serviceDto);
      if (createdService == null)
      {
        return BadRequest("Impossible de créer le site.");
      }
      return CreatedAtAction(nameof(CreateService), new { id = createdService.ServiceId }, serviceDto);
    }
    catch (ArgumentException ex)
    {
      return BadRequest(ex.Message);
    }
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

  [HttpPut("{id}")]
  // public ActionResult Update(int id, [FromBody] ServiceUpdateDTO serviceDto)
  // {
  //   var updatedService = _serviceService.UpdateService(id, serviceDto);
  //   if (updatedService == null)
  //   {
  //     return BadRequest("Impossible de modifier cet employé.");
  //   }
  //   return Ok(serviceDto);
  // }

  public ActionResult Update(int id, ServiceUpdateDTO serviceDto)
  {
    try
    {
      var updatedService = _serviceService.UpdateService(id, serviceDto);
      return Ok(updatedService);
    }
    catch (ArgumentException ex)
    {
      return NotFound(ex.Message); // Renvoie un 404 Not Found avec le message d'erreur
    }
  }

  [HttpDelete("{id}")]
  public ActionResult DeleteService(int id)
  {
    try
    {
      bool success = _serviceService.DeleteService(id);
      if (!success)
      {
        return NotFound("Le service n'existe pas.");
      }
      return Ok("Suppression du service OK");
    }
    catch (ArgumentException ex)
    {
      return Conflict(ex.Message);
    }
  }




}

