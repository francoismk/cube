namespace Namespace;
using cube;

public class ServiceService
{
    private readonly IRepositoryService _serviceRepository;

    private readonly IRepositoryData<Location> _locationRepository;

    public ServiceService(IRepositoryService serviceRepository, IRepositoryData<Location> locationRepository)
    {
        _serviceRepository = serviceRepository;
        _locationRepository = locationRepository;
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


    public Service? CreateService(ServiceCreateDTO serviceDto)
    {
        // Vérifier l'existence de la localisation
        var location = _locationRepository.GetAll().FirstOrDefault(l => l.LocationName == serviceDto.LocationName);
        if (location == null)
        {
            throw new ArgumentException("Localisation non trouvée.");
        }

        // Créer l'employé
        var service = new Service(serviceDto.ServiceName)
        {
            ServiceName = serviceDto.ServiceName,
            LocationId = location.Id,

        };

        _serviceRepository.Create(service);
        return service;
    }

    // public Service? UpdateService(int id, ServiceUpdateDTO serviceUpdateDto)
    // {
    //     // Récupérer le service existant
    //     var existingService = _serviceRepository.GetById(id);
    //     if (existingService == null)
    //     {
    //         throw new ArgumentException("Service non trouvé.");
    //     }

    //     // Vérifier et mettre à jour le nom du service si un nouveau nom est fourni
    //     if (!string.IsNullOrEmpty(serviceUpdateDto.ServiceName))
    //     {
    //         existingService.ServiceName = serviceUpdateDto.ServiceName;
    //     }

    //     // Vérifier et mettre à jour la localisation du service si un nouveau nom de localisation est fourni
    //     if (!string.IsNullOrEmpty(serviceUpdateDto.LocationName))
    //     {
    //         var location = _locationRepository.GetAll().FirstOrDefault(l => l.LocationName == serviceUpdateDto.LocationName);
    //         if (location == null)
    //         {
    //             throw new ArgumentException("Localisation non trouvée.");
    //         }
    //         existingService.LocationId = location.Id;
    //     }

    //     // Mettre à jour le service dans le repository
    //     _serviceRepository.Update(existingService);
    //     return existingService;
    // }


    public ServiceUpdateDTO? UpdateService(int id, ServiceUpdateDTO serviceUpdateDto)
    {
        var existingService = _serviceRepository.GetById(id);
        if (existingService == null)
        {
            throw new ArgumentException("Site non trouvé.");
        }

        existingService.ServiceName = serviceUpdateDto.ServiceName;



        _serviceRepository.Update(existingService);
        return serviceUpdateDto;
    }

    public bool DeleteService(int serviceId)
    {
        var service = _serviceRepository.GetByIdWithEmployees(serviceId);
        if (service == null) return false;

        if (service.Employees.Any())
        {
            // S'il y a des employés affectés, vous ne pouvez pas supprimer le service
            throw new ArgumentException("Employé existant dans ce service");
        }

        _serviceRepository.Delete(service);
        return true;
    }

}

