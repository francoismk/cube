using cube;

namespace Namespace;
public class LocationService
{
    private readonly IRepositoryLocation _locationRepository;
    private readonly IRepositoryEmployee _employeeRepository;
    private readonly IRepositoryService _serviceRepository;

    public LocationService(IRepositoryLocation locationRepository, IRepositoryEmployee employeeRepository, IRepositoryService serviceRepository)
    {
        _locationRepository = locationRepository;
        _employeeRepository = employeeRepository;
        _serviceRepository = serviceRepository;
    }

    public List<LocationDTO> GetAllWithService()
    {
        var locations = _locationRepository.GetAllWithService();
        return locations.Select(location => new LocationDTO
        {
            LocationId = location.Id,
            LocationName = location.LocationName,
            ServiceName = location.Services.Select(service => service.ServiceName).ToList()
        }).ToList();
    }

    public LocationDTO? GetLocationById(int id)
    {
        var location = _locationRepository.GetById(id);
        if (location == null)
        {
            return null;
        }

        var locationDto = new LocationDTO
        {
            LocationId = location.Id,
            LocationName = location.LocationName,
            ServiceName = location.Services.Select(service => service.ServiceName).ToList()
        };

        return locationDto;
    }

    public Location? CreateLocation(LocationCreateDTO locationCreateDTO)
    {
        var location = new Location
        {
            LocationName = locationCreateDTO.LocationName
        };
        _locationRepository.Create(location);
        return location;
    }

    public bool DeleteLocation(int locationId)
    {
        // Récupérer la localisation par son ID
        var location = _locationRepository.GetById(locationId);
        if (location == null)
        {
            // La localisation n'existe pas
            return false; // Retourne false pour indiquer que la suppression n'a pas eu lieu
        }

        // Vérifier si des services sont liés à la localisation
        var services = _serviceRepository.GetServicesByLocationId(locationId);
        foreach (var service in services)
        {
            // Vérifiez si des employés sont liés à ces services
            var employees = _employeeRepository.GetByServiceId(service.ServiceId);
            if (employees.Any())
            {
                // Des employés sont liés à un service de cette localisation
                return false; // Empêche la suppression
            }
        }

        // Si aucune vérification n'échoue, supprimer la localisation
        _locationRepository.Delete(location); // Assurez-vous que les changements sont enregistrés
        return true; // La suppression a réussi
    }

    public Location? UpdateLocation(int id, LocationUpdateDTO locationUpdateDto)
    {
        var existingLocation = _locationRepository.GetById(id);
        if (existingLocation == null)
        {
            throw new ArgumentException("Site non trouvé.");
        }

        existingLocation.LocationName = locationUpdateDto.LocationName;



        _locationRepository.Update(existingLocation);
        return existingLocation;
    }




}
