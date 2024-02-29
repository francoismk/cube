

using Microsoft.AspNetCore.Mvc;

namespace cube;
[Route("api/[controller]")]
[ApiController]
public class ServiceController : ControllerBase
{
  private readonly IRepositoryData<Service> ?_serviceRepository;

  private readonly IRepositoryData<Employee> ?_employeeRepository;

  public ServiceController(IRepositoryData<Service> serviceRepository, IRepositoryData<Employee> employeeRepository) {
    _serviceRepository = serviceRepository;
    _employeeRepository = employeeRepository;
  }

  [HttpPost]
  public IActionResult PostService(ServiceDTO dto) {
    Service service = new Service {
    ServiceName = dto.ServiceName,
    ServiceDescription = dto.ServiceDescription,
    Employees = SetEmployee(dto.Employees)
};
    _serviceRepository.Create(service);
    return CreatedAtAction(nameof(PostService), new {
        Message = "Service crée",
        Service = service
    });
  }

  [HttpGet]
  public IActionResult GetService(){
    var services = _serviceRepository?.GetAll();
    return Ok(services);
  }

  private List<Employee> SetEmployee(List<int> employeeInt) {
    List<Employee> employees = new List<Employee>();
    foreach (int i in employeeInt) {
        var found = _employeeRepository?.GetById(i);
        if (found != null) {
            employees.Add(found);
        }
    }
        return employees;
  }

  
}
