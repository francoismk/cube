
using Microsoft.EntityFrameworkCore;

namespace cube;

public class ServiceRepository : BaseRepository, IRepositoryData<Service>
{

    public ServiceRepository(ApplicationDbContext dbContext) : base(dbContext) {}
    public bool Create(Service entity)
    {
        _dbContext.Add(entity);
        _dbContext.SaveChanges();
        return true;
    }

    public bool Delete(Service entity)
    {
        var found = GetById(entity.ServiceId);
        if(found == null) return false;
        _dbContext.Remove(found);
        _dbContext.SaveChanges();
        return true;
    }

    public List<Service> GetAll()
    {
        return _dbContext.Services.Include( service => service.Employees).ToList();
    }

    public Service? GetById(int id)
    {
        return _dbContext.Services.Include(service => service.Employees).FirstOrDefault(service => service.ServiceId == id);
    }

    public bool Update(Service entity)
    {
        var found = GetById(entity.ServiceId);
        if (found == null ) return false;
        foreach(var prop in typeof(Service).GetProperties()) {
            if (prop.Name != "ServiceId") prop.SetValue(found, prop.GetValue(entity));
        }
        _dbContext.Update(found);
        _dbContext.SaveChanges();
        return true;
    }
}
