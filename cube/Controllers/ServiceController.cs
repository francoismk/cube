

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
}
