namespace Namespace;
using cube;

public class ServiceService
{
    private readonly IRepositoryService _serviceRepository;

    public ServiceService(IRepositoryService serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public List<ServiceDTO> GetAllServicesWithLocations()
    {
        var services = _serviceRepository.GetAll();
        return services.Select(service => new ServiceDTO
        {
            ServiceId = service.ServiceId,
            ServiceName = service.ServiceName,
            LocationName = service.Location.LocationName
        }).ToList();
    }

    public ServiceDTO? GetServiceById(int id)
    {
        var service = _serviceRepository.GetById(id);
        if (service == null)
        {
            return null;
        }

        var serviceDto = new ServiceDTO
        {
            ServiceId = service.ServiceId,
            ServiceName = service.ServiceName,
            LocationName = service.Location?.LocationName
        };

        return serviceDto;
    }

    public List<ServiceDTO> GetServicesByLocationName(string locationName)
    {
        var services = _serviceRepository.GetServicesByLocationName(locationName);
        return services.Select(service => new ServiceDTO
        {
            ServiceId = service.ServiceId,
            ServiceName = service.ServiceName,
            LocationName = service.Location.LocationName
        }).ToList();
    }
}