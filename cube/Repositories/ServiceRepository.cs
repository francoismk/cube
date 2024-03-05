
using Microsoft.EntityFrameworkCore;
using Namespace;

namespace cube;

public class ServiceRepository : BaseRepository, IRepositoryService, IRepositoryData<Service>
{

    public ServiceRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    public bool Create(Service entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "Le service fourni est null.");
        }
        try
        {
            _dbContext.Services.Add(entity);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Erreur lors de la création du service.", ex);
        }
    }

    public bool Delete(Service entity)
    {
        _dbContext.Remove(entity);
        _dbContext.SaveChanges();
        return true;
    }

    public List<Service> GetAll()
    {
        return _dbContext.Services.Include(service => service.Location).ToList();
    }

    public Service? GetById(int id)
    {
        return _dbContext.Services
        .Include(service => service.Location)
        .FirstOrDefault(service => service.ServiceId == id);
    }

    public bool Update(Service entity)
    {
        var existingService = _dbContext.Services.Find(entity.ServiceId);
        if (existingService == null)
        {
            return false;
        }

        _dbContext.Entry(existingService).CurrentValues.SetValues(entity);
        _dbContext.SaveChanges();
        return true;
    }

    public List<Service> GetServicesByLocationName(string locationName)
    {
        return _dbContext.Services
            .Include(service => service.Location)
            .Where(service => service.Location.LocationName == locationName)
            .ToList();
    }


    public List<Service> GetServicesByLocationId(int id)
    {
        return _dbContext.Services
            .Include(service => service.Location)
            .Where(service => service.Location.Id == id)
            .ToList();
    }

    public Service? GetByIdWithEmployees(int id)
    {
        return _dbContext.Services
        .Include(s => s.Employees)
        .FirstOrDefault(s => s.ServiceId == id);
    }



}
