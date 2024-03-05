
using Microsoft.EntityFrameworkCore;

namespace cube;

public class EmployeeRepository : BaseRepository, IRepositoryEmployee, IRepositoryData<Employee>
{
    public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    public bool Create(Employee entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "L'employé fourni est null.");
        }
        try
        {
            _dbContext.Employees.Add(entity);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Erreur lors de la création de l'employé.", ex);
        }
    }

    public bool Delete(Employee entity)
    {
        _dbContext.Remove(entity);
        _dbContext.SaveChanges();
        return true;
    }

    public List<Employee> GetAll()
    {
        return _dbContext.Employees
            .Include(e => e.Service)
            .ThenInclude(s => s.Location)
            .ToList();
    }

    public Employee? GetById(int id)
    {
        return _dbContext.Employees
            .Include(e => e.Service)
            .ThenInclude(s => s.Location)
            .SingleOrDefault(e => e.EmployeeId == id);
    }

    public bool Update(Employee entity)
    {
        var existingEmployee = _dbContext.Employees.Find(entity.EmployeeId);
        if (existingEmployee == null)
        {
            return false;
        }

        _dbContext.Entry(existingEmployee).CurrentValues.SetValues(entity);
        _dbContext.SaveChanges();
        return true;
    }

    public IEnumerable<Employee> GetAllWithServiceAndLocation()
    {
        return _dbContext.Employees
            .Include(e => e.Service)
            .ThenInclude(s => s.Location)
            .ToList();
    }

    public IEnumerable<Employee> GetByServiceName(string serviceName)
    {
        return _dbContext.Employees
            .Include(e => e.Service)
            .ThenInclude(s => s.Location)
            .Where(e => e.Service.ServiceName == serviceName)
            .ToList();
    }


    public IEnumerable<Employee> GetByServiceId(int id)
    {
        return _dbContext.Employees
            .Include(e => e.Service)
            .ThenInclude(s => s.Location)
            .Where(e => e.Service.ServiceId == id)
            .ToList();
    }

    public IEnumerable<Employee> GetByServiceAndLocation(string serviceName, string locationName)
    {
        return _dbContext.Employees
            .Include(e => e.Service)
                .ThenInclude(s => s.Location)
            .Where(e => e.Service.ServiceName == serviceName && e.Service.Location.LocationName == locationName)
            .ToList();
    }



}
