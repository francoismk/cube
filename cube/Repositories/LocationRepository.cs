using cube;
using Microsoft.EntityFrameworkCore;

namespace Namespace;
public class LocationRepository : BaseRepository, IRepositoryLocation, IRepositoryData<Location>
{

    public LocationRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    public bool Create(Location entity)
    {
        _dbContext.Add(entity);
        _dbContext.SaveChanges();
        return true;
    }

    public bool Delete(Location entity)
    {
        _dbContext.Remove(entity);
        _dbContext.SaveChanges();
        return true;
    }

    public List<Location> GetAll()
    {
        return _dbContext.Locations.ToList();
    }

    public IEnumerable<Location> GetAllWithService()
    {
        return _dbContext.Locations.Include(location => location.Services).ToList();
    }

    public Location? GetById(int id)
    {
        return _dbContext.Locations
            .Include(location => location.Services)
            .FirstOrDefault(location => location.Id == id);
    }

    public bool Update(Location entity)
    {
        var existingLocation = _dbContext.Locations.Find(entity.Id);
        if (existingLocation == null)
        {
            return false;
        }

        _dbContext.Entry(existingLocation).CurrentValues.SetValues(entity);
        _dbContext.SaveChanges();
        return true;
    }


}
