using cube;
using Microsoft.EntityFrameworkCore;

namespace Namespace;
public class EmployeeService
{
    private readonly IRepositoryEmployee _employeeRepository;
    private readonly IRepositoryData<Service> _serviceRepository;
    private readonly IRepositoryData<Location> _locationRepository;

    public EmployeeService(
        IRepositoryEmployee employeeRepository,
        IRepositoryData<Service> serviceRepository,
        IRepositoryData<Location> locationRepository)
    {
        _employeeRepository = employeeRepository;
        _serviceRepository = serviceRepository;
        _locationRepository = locationRepository;
    }

    public List<EmployeeDTO> GetAll()
    {
        var employees = _employeeRepository.GetAll();
        if (employees == null)
        {
            return new List<EmployeeDTO>();
        }

        var employeesDto = employees.Select(employee => new EmployeeDTO
        {
            EmployeeId = employee.EmployeeId,
            EmployeeFirstName = employee.EmployeeFirstName,
            EmployeeLastName = employee.EmployeeLastName,
            EmployeeLandline = employee.EmployeeLandline,
            EmployeePhoneNumber = employee.EmployeePhoneNumber,
            EmployeeEmail = employee.EmployeeEmail,
            ServiceName = employee.Service?.ServiceName,
            LocationName = employee.Service?.Location?.LocationName
        }).ToList();

        return employeesDto;
    }
    public EmployeeDTO? GetById(int id)
    {
        var employee = _employeeRepository.GetById(id);
        if (employee == null)
        {
            return null;
        }
        var employeeDto = new EmployeeDTO
        {
            EmployeeId = employee.EmployeeId,
            EmployeeFirstName = employee.EmployeeFirstName,
            EmployeeLastName = employee.EmployeeLastName,
            EmployeeLandline = employee.EmployeeLandline,
            EmployeePhoneNumber = employee.EmployeePhoneNumber,
            EmployeeEmail = employee.EmployeeEmail,
            ServiceName = employee.Service?.ServiceName,
            LocationName = employee.Service?.Location?.LocationName
        };

        return employeeDto;
    }


    public List<EmployeeDTO> GetEmployeeByLocation(string locationName)
    {
        var employeesDto = _employeeRepository.GetAllWithServiceAndLocation()
            .Where(e => e.Service.Location.LocationName == locationName)
            .Select(e => new EmployeeDTO
            {
                EmployeeId = e.EmployeeId,
                EmployeeFirstName = e.EmployeeFirstName,
                EmployeeLastName = e.EmployeeLastName,
                EmployeeLandline = e.EmployeeLandline,
                EmployeePhoneNumber = e.EmployeePhoneNumber,
                EmployeeEmail = e.EmployeeEmail,
                ServiceName = e.Service.ServiceName,
                LocationName = e.Service.Location.LocationName
            })
            .ToList();

        return employeesDto;
    }

    public List<EmployeeDTO> GetEmployeesByServiceName(string serviceName)
    {
        var employees = _employeeRepository.GetByServiceName(serviceName);

        var employeesDto = employees.Select(employee => new EmployeeDTO
        {
            EmployeeId = employee.EmployeeId,
            EmployeeFirstName = employee.EmployeeFirstName,
            EmployeeLastName = employee.EmployeeLastName,
            EmployeeLandline = employee.EmployeeLandline,
            EmployeePhoneNumber = employee.EmployeePhoneNumber,
            EmployeeEmail = employee.EmployeeEmail,
            ServiceName = employee.Service.ServiceName,
            LocationName = employee.Service.Location.LocationName
        }).ToList();

        return employeesDto;
    }

    public List<EmployeeDTO> GetEmployeesByServiceAndLocation(string serviceName, string locationName)
    {
        var employees = _employeeRepository.GetByServiceAndLocation(serviceName, locationName);

        var employeesDto = employees.Select(employee => new EmployeeDTO
        {
            EmployeeId = employee.EmployeeId,
            EmployeeFirstName = employee.EmployeeFirstName,
            EmployeeLastName = employee.EmployeeLastName,
            EmployeeLandline = employee.EmployeeLandline,
            EmployeePhoneNumber = employee.EmployeePhoneNumber,
            EmployeeEmail = employee.EmployeeEmail,
            ServiceName = employee.Service?.ServiceName,
            LocationName = employee.Service?.Location?.LocationName
        }).ToList();

        return employeesDto;
    }

    public Employee? CreateEmployee(EmployeeCreateDTO employeeDto)
    {
        // Vérifier l'existence du service
        var service = _serviceRepository.GetAll().FirstOrDefault(s => s.ServiceName == employeeDto.ServiceName);
        if (service == null)
        {
            throw new ArgumentException("Service non trouvé.");
        }

        // Vérifier l'existence de la localisation
        var location = _locationRepository.GetAll().FirstOrDefault(l => l.LocationName == employeeDto.LocationName);
        if (location == null)
        {
            throw new ArgumentException("Localisation non trouvée.");
        }

        // Assurer que le service appartient à la localisation spécifiée
        if (service.LocationId != location.Id)
        {
            throw new ArgumentException("Le service n'appartient pas à la localisation spécifiée.");
        }

        // Créer l'employé
        var employee = new Employee
        {
            EmployeeFirstName = employeeDto.EmployeeFirstName,
            EmployeeLastName = employeeDto.EmployeeLastName,
            EmployeeLandline = employeeDto.EmployeeLandline,
            EmployeePhoneNumber = employeeDto.EmployeePhoneNumber,
            EmployeeEmail = employeeDto.EmployeeEmail,
            ServiceId = service.ServiceId,
        };

        _employeeRepository.Create(employee);
        return employee;
    }

    public Employee? UpdateEmployee(int id, EmployeeUpdateDTO employeeUpdateDto)
    {
        var existingEmployee = _employeeRepository.GetById(id);
        if (existingEmployee == null)
        {
            throw new ArgumentException("Employé non trouvé.");
        }

        var service = _serviceRepository.GetAll().FirstOrDefault(s => s.ServiceName == employeeUpdateDto.ServiceName);
        if (service == null)
        {
            throw new ArgumentException("Service non trouvé.");
        }

        var location = _locationRepository.GetAll().FirstOrDefault(l => l.LocationName == employeeUpdateDto.LocationName);
        if (location == null)
        {
            throw new ArgumentException("Localisation non trouvée.");
        }

        if (service.LocationId != location.Id)
        {
            throw new ArgumentException("Le service n'appartient pas à la localisation spécifiée.");
        }

        existingEmployee.EmployeeFirstName = employeeUpdateDto.EmployeeFirstName;
        existingEmployee.EmployeeLastName = employeeUpdateDto.EmployeeLastName;
        existingEmployee.EmployeeLandline = employeeUpdateDto.EmployeeLandline;
        existingEmployee.EmployeePhoneNumber = employeeUpdateDto.EmployeePhoneNumber;
        existingEmployee.EmployeeEmail = employeeUpdateDto.EmployeeEmail;
        existingEmployee.ServiceId = service.ServiceId;


        _employeeRepository.Update(existingEmployee);
        return existingEmployee;
    }

    public bool DeleteEmployee(int id)
    {
        var employee = _employeeRepository.GetById(id);
        if (employee == null)
        {

            return true;
        }


        _employeeRepository.Delete(employee);
        return true;
    }
}
