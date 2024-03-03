using Microsoft.AspNetCore.Mvc;
using Namespace;

namespace cube;
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeService _employeeService;


    public EmployeeController(EmployeeService employeeService)
    {
        _employeeService = employeeService;

    }


    [HttpPost]
    public IActionResult CreateEmployee([FromBody] EmployeeCreateDTO employeeDto)
    {
        try
        {
            var createdEmployee = _employeeService.CreateEmployee(employeeDto);
            if (createdEmployee == null)
            {
                return BadRequest("Impossible de créer l'employé.");
            }
            // Utilisez l'ID de l'employé créé ici
            return CreatedAtAction(nameof(CreateEmployee), new { id = createdEmployee.EmployeeId }, employeeDto);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("All")]
    public IActionResult GetAll()
    {
        var employeeDto = _employeeService.GetAll();
        if (employeeDto == null)
        {
            return NotFound($"Aucun employé trouvé");
        }
        return Ok(employeeDto);
    }

    [HttpGet("ById/{id}")]
    public IActionResult GetById(int id)
    {
        var employeeDto = _employeeService.GetById(id);
        if (employeeDto == null)
        {
            return NotFound($"Aucun employé trouvé avec l'ID {id}.");
        }
        return Ok(employeeDto);
    }

    [HttpGet("ByService/{serviceName}")]
    public IActionResult GetByService(string serviceName)
    {
        var employeesDto = _employeeService.GetEmployeesByServiceName(serviceName);
        if (!employeesDto.Any())
        {
            return NotFound($"Aucun employé trouvé dans le service {serviceName}.");
        }
        return Ok(employeesDto);
    }

    [HttpGet("ByLocation/{locationName}")]
    public IActionResult GetEmployeeByLocation(string locationName)
    {
        var employees = _employeeService.GetEmployeeByLocation(locationName);
        if (employees == null)
        {
            return NotFound($"Aucun employé trouvé à {locationName}.");
        }
        return Ok(employees);
    }

    [HttpGet("ByServiceAndLocation/{serviceName}/{locationName}")]
    public IActionResult GetByServiceAndLocation(string serviceName, string locationName)
    {
        var employeesDto = _employeeService.GetEmployeesByServiceAndLocation(serviceName, locationName);
        if (employeesDto == null || !employeesDto.Any())
        {
            return NotFound($"Aucun employé trouvé dans le service {serviceName} à {locationName}.");
        }
        return Ok(employeesDto);
    }

}

